namespace CollabRestDemo.bbdn.collab.rest.models
{
    class Session
    {
        public string id { get; set; }

        public string guestUrl { get; set; }

        public bool allowInSessionInvitees { get; set; }

        public string guestRole { get; set; }

        public bool openChair { get; set; }

        public string sessionExitUrl { get; set; }

        public bool mustBeSupervised { get; set; }

        public bool noEndDate { get; set; }

        public string description { get; set; }

        public RecurrenceRule recurrenceRule { get; set; }

        public string occurrenceType { get; set; }

        public bool canPostMessage { get; set; }

        public string createdTimezone { get; set; }

        public bool participantCanUseTools { get; set; }

        public bool courseRoomEnabled { get; set; }

        public bool canAnnotateWhiteboard { get; set; }

        public bool canDownloadRecording { get; set; }

        public bool canShareVideo { get; set; }

        public string name { get; set; }

        public bool raiseHandOnEnter { get; set; }

        public string boundaryTime { get; set; }

        public System.DateTime startTime { get; set; }

        public bool allowGuest { get; set; }

        public System.DateTime endTime { get; set; }

        public bool showProfile { get; set; }

        public bool canShareAudio { get; set; }

        public override string ToString() => "{  \"guestUrl\" : \""
                                             + guestUrl
                                             + "\","
                                             + "\"name\" : \""
                                             + name
                                             + "\","
                                             + "\"guestRole\" : \""
                                             + guestRole
                                             + "\","
                                             + "\"occurrenceType\" : \""
                                             + occurrenceType
                                             + "\","
                                             + "\"description\" : \""
                                             + description
                                             + "\","
                                             + "\"startTime\" : \""
                                             + startTime.ToString()
                                             + "\","
                                             + "\"endTime\" : \""
                                             + endTime.ToString()
                                             + "\"     }";

    }
}
