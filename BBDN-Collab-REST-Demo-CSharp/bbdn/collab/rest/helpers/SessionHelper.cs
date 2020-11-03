using CollabRestDemo.bbdn.collab.rest.models;
using System;

namespace CollabRestDemo.bbdn.collab.rest.helpers
{
    class SessionHelper
    {
        public static Session GenerateObject()
        {
            Session session = new Session();
           
            session.allowInSessionInvitees = true;
            session.guestRole = "presenter";
            session.openChair = true;
            session.sessionExitUrl = "https://community.blackboard.com/community/developers";
            session.startTime = DateTime.UtcNow;
            session.endTime = DateTime.UtcNow.AddMonths(1);
            session.mustBeSupervised = true;
            session.noEndDate = true;
            session.description = "Collab API demo room created with C#";
            session.canPostMessage = true;
            session.participantCanUseTools = true;
            session.courseRoomEnabled = true;
            session.canAnnotateWhiteboard = true;
            session.canDownloadRecording = true;
            session.canShareVideo = true;
            session.name = "Collab API C# Demo Room";
            session.raiseHandOnEnter = false;
            session.allowGuest = true;
            session.showProfile = true;
            session.canShareAudio = true;
            session.boundaryTime = "";
            session.createdTimezone = "";
            session.occurrenceType = "S";
            session.recurrenceRule = RecurrenceHelper.GenerateObject();

            return (session);
        }

    }
}
