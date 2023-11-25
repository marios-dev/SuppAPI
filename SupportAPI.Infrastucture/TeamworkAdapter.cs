using Microsoft.Extensions.Logging;
using SupportAPI.Domain;
using SupportAPI.Domain.BusinessModels;
using SupportAPI.Domain.Contracts;
using SupportAPI.Domain.Interfaces.Infrastructure;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SupportAPI.Infrastucture
{
    public class TeamworkAdapter : ITeamworkAdapter
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TeamworkAdapter> _logger;

        public TeamworkAdapter(IHttpClientFactory httpClientFactory, ILogger<TeamworkAdapter> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<TeamworkTicket?> GetFullTicketAsync(long id)
        {
            try
            {
                using (var teamworkClient = _httpClientFactory.CreateClient(Constants.HttpClientTeamwork))
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, teamworkClient.BaseAddress + ""); //TODO CHECK URL
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");
                    using var response = await teamworkClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        using var jsonStream = await response.Content.ReadAsStreamAsync();
                        var deserializedTeamworkTicket = await JsonSerializer.DeserializeAsync<TeamworkTicket>(jsonStream);
                        if (deserializedTeamworkTicket is not null)
                        {
                            return deserializedTeamworkTicket;
                        }
                    }
                    else
                    {
                        _logger.LogError("Method: {Method} {context}", nameof(ChangeTeamworkTicketStatusAsync), response.Content);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.LogError("Method: {Method} {exception}", nameof(ChangeTeamworkTicketStatusAsync), exception);
                throw;
            }
            return null;
        }

        public async Task<TeamworkTicket?> ChangeTeamworkTicketStatusAsync(Stream stream, int statusId)
        {
            try
            {
                var deserializedTicket = await JsonSerializer.DeserializeAsync<TeamworkTicket>(stream);
                if (deserializedTicket == null)
                {
                    return null;
                }
                deserializedTicket.ChangeTicketStatusTo(statusId);
                var teamworkClient = _httpClientFactory.CreateClient(Constants.HttpClientTeamwork);
                var jsonContent = JsonSerializer.Serialize(deserializedTicket);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                using (teamworkClient)
                {
                    var request = new HttpRequestMessage(HttpMethod.Patch, teamworkClient.BaseAddress + "tickets/" + $"{deserializedTicket.Ticket.Id}.json");
                    request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");
                    using var response = await teamworkClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        using var jsonStream = await response.Content.ReadAsStreamAsync();
                        var deserializedTeamworkTicket = await JsonSerializer.DeserializeAsync<TeamworkTicket>(jsonStream);
                        if (deserializedTeamworkTicket is not null)
                        {
                            return deserializedTeamworkTicket;
                        }
                    }
                    else
                    {
                        _logger.LogError("Method: {Method} {context}", nameof(ChangeTeamworkTicketStatusAsync), response.Content);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.LogError("Method: {Method} {exception}", nameof(ChangeTeamworkTicketStatusAsync), exception);
                throw;
            }
            return null;
        }

        public async Task<TeamworkTicket?> ChangeTeamworkTicketStatusAsync(long id, int statusId)
        {
            try
            {
                var deserializedTicket = new TeamworkTicket()
                {
                    Ticket = new Ticket()
                    {
                        Id = id
                    }
                };
                deserializedTicket.ChangeTicketStatusTo(statusId);
                var teamworkClient = _httpClientFactory.CreateClient(Constants.HttpClientTeamwork);
                var jsonContent = JsonSerializer.Serialize(deserializedTicket);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                using (teamworkClient)
                {
                    var request = new HttpRequestMessage(HttpMethod.Patch, teamworkClient.BaseAddress + "tickets/" + $"{id}.json");
                    request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "tkn.v1_MDJmYWY3MWUtMTQ0OC00ZWZmLWE1OTctZjRkNDUxYTEwNTk1LTYyODIxMi40ODAzNjguRVU=");
                    using var response = await teamworkClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        using var jsonStream = await response.Content.ReadAsStreamAsync();
                        var deserializedTeamworkTicket = await JsonSerializer.DeserializeAsync<TeamworkTicket>(jsonStream);
                        if (deserializedTeamworkTicket is not null)
                        {
                            return deserializedTeamworkTicket;
                        }
                    }
                    else
                    {
                        _logger.LogError("Method: {Method} {context}", nameof(ChangeTeamworkTicketStatusAsync), response.Content);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.LogError("Method: {Method} {exception}", nameof(ChangeTeamworkTicketStatusAsync), exception);
                throw;
            }
            return null;
        }


        public async Task<TeamhoodBoardStatus> GetTeamhoodBoardStatusesAsync(string boardId)
        {
            throw new NotImplementedException();
        }
    }
}
