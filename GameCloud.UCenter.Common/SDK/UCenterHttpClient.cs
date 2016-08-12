﻿

namespace GameCloud.UCenter
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;

    public class UCenterHttpClient
    {
        HttpClient httpClient = null;

        public UCenterHttpClient()
        {
            var handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            handler.ClientCertificateOptions = ClientCertificateOption.Automatic;

            this.httpClient = new HttpClient(handler);
            this.httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public Task<TResponse> SendAsync<TContent, TResponse>(HttpMethod method, string url, TContent content)
        {
            HttpContent httpContent = null;
            if (content is HttpContent)
            {
                httpContent = content as HttpContent;
            }
            else
            {
                httpContent = new ObjectContent<TContent>(content, new JsonMediaTypeFormatter());
            }

            return this.SentAsync<TResponse>(method, url, httpContent);
        }

        public async Task<TResponse> SentAsync<TResponse>(HttpMethod method, string url, HttpContent content)
        {
            //using (var httpClient = CreateHttpClient())

            var request = new HttpRequestMessage(method, new Uri(url));
            request.Headers.Clear();
            request.Headers.ExpectContinue = false;
            request.Content = content;

            var response = await this.httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<TResponse>();
        }

        public async Task<TResult> SendAsyncWithException<TContent, TResult>(HttpMethod method, string url,
            TContent content)
        {
            var response = await this.SendAsync<TContent, UCenterResponse<TResult>>(method, url, content);
            if (response.Status == UCenterResponseStatus.Success)
            {
                return response.Result;
            }

            if (response.Error != null)
            {
                throw new UCenterException(response.Error.ErrorCode, response.Error.Message);
            }

            throw new UCenterException(UCenterErrorCode.Failed, "Error occurred when sending http request");
        }

        public void Close()
        {
            if (this.httpClient != null)
            {
                this.httpClient.Dispose();
                this.httpClient = null;
            }
        }
    }
}
