using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using VkNet.Abstractions.Utils;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Utils
{
	/// <inheritdoc />
	public class RestClient : IRestClient
	{
		/// <summary>
		/// The log
		/// </summary>
		private readonly ILogger _logger;

		private TimeSpan _timeoutSeconds;

		private readonly HttpClient _httpClient;

		/// <inheritdoc />
		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		public RestClient(ILogger logger, IWebProxy proxy) : this(logger, proxy, TimeSpan.FromSeconds(300))
		{
		}

		/// <inheritdoc />
		public RestClient(ILogger logger, IWebProxy proxy, TimeSpan timeout)
		{
			_logger = logger;

			var handler = new HttpClientHandler
			{
				UseProxy = proxy != null
			};
			if (proxy != null)
			{
				handler.Proxy = proxy;
			}

			_httpClient = new HttpClient(handler) {Timeout = timeout};
			Proxy = proxy;
			Timeout = timeout;
		}

		/// <inheritdoc />
		public TimeSpan Timeout
		{
			get => _timeoutSeconds == TimeSpan.Zero ? TimeSpan.FromSeconds(value: 300) : _timeoutSeconds;
			set => _timeoutSeconds = value;
		}

		/// <inheritdoc />
		public async Task<HttpResponse<string>> GetAsync(Uri uri, VkParameters parameters)
		{
			var queries = parameters.Where(predicate: k => !string.IsNullOrWhiteSpace(value: k.Value))
				.Select(selector: kvp => $"{kvp.Key.ToLowerInvariant()}={kvp.Value}");

			var url = new UriBuilder(uri: uri)
			{
				Query = string.Join(separator: "&", values: queries)
			};

			_logger?.Debug(message: $"GET request: {url.Uri}");

			return await Call(method: httpClient => httpClient.GetAsync(requestUri: url.Uri)).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<HttpResponse<string>> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			var json = JsonConvert.SerializeObject(value: parameters);
			_logger?.Debug(message: $"POST request: {uri}{Environment.NewLine}{Utilities.PreetyPrintJson(json: json)}");
			HttpContent content = new FormUrlEncodedContent(nameValueCollection: parameters);

			return await Call(method: httpClient => httpClient.PostAsync(requestUri: uri, content: content))
				.ConfigureAwait(false);
		}

		private async Task<HttpResponse<string>> Call(Func<HttpClient, Task<HttpResponseMessage>> method)
		{
			ServicePointManager.DefaultConnectionLimit = 50;
			var response = await method(arg: _httpClient).ConfigureAwait(false);
			var requestUri = response.RequestMessage.RequestUri.ToString();

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				_logger?.Debug(message: $"Response:{Environment.NewLine}{Utilities.PreetyPrintJson(json: json)}");

				return HttpResponse<string>.Success(httpStatusCode: response.StatusCode, value: json,
					requestUri: requestUri);
			}

			var message = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			return HttpResponse<string>.Fail(httpStatusCode: response.StatusCode, message: message,
				requestUri: requestUri);
		}


		/// <inheritdoc />
		~RestClient()
		{
			_httpClient.Dispose();
		}
	}
}