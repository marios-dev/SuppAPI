namespace SupportAPI.Domain
{
    public static class Constants
    {
        public const string TicketCreated = "ticket.created";
        public const string TicketStatus = "ticket.status";
        public const string HttpClientTeamwork = "TeamworkClient";
        public const string HttpClientTeamhood = "TeamhoodClient";
        public const int None = 0;

        public static class TeamWorkStatusIdFor
        {
            public const int ToTeamhood = 0;
            public const int Closed = 0;
            public const int Active = 0;
            public const int Waiting = 0;
            public const int CreatedInTeamhood = 0;
        }

        public static class HttpStatusCode
        {
            public const int Success = 200;
            public const int BadRequest = 404;
        }
        public static class TeamhoodTaskInfo
        {
            public static readonly Guid WorkspaceID = new Guid("");
            public static readonly Guid BoardID = new Guid("");
            public static readonly Guid RowID = new Guid("");
            public static readonly Guid ToDoStatusID = new Guid("");
            public static readonly string TeamworkCompanyEndpoint = "";

        }
    }
}
