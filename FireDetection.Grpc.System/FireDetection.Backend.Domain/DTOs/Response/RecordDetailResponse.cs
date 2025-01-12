﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDetection.Backend.Domain.DTOs.Response
{
    public class RecordDetailResponse
    {
        public Guid CameraId { get; set; }
        public int RecordType {  get; set; }
        public string CameraDestination { get; set; } = string.Empty;
        public string CameraName { get; set; } = string.Empty;
        public string RecommendAlarmLevel { get; set; } = string.Empty;
        public string RecordTime { get; set; } = string.Empty;
        public string FinishTime { get; set; } = string.Empty;
        public Guid RecordId { get; set; }
        public decimal PredictedPercent { get; set; }
        public string Status { get; set; }
        public VideoRecord VideoRecord { get; set; } = null!;
        public ImageRecord ImageRecord { get; set; } = null!;
        public List<UserRating> userRatings { get; set; } = null!;
        public List<UserVoting> userVoting { get; set; } = null!;
        public List<string> evidences { get; set; } = null!;
        public UserInLocationResponse AlarmUser { get; set;} = null!;
        public List<UserResponsibility> userResponsibilities { get; set; } = null!;
    }

   
    public class VideoRecord
    {
        public string? VideoUrl { get; set; }
    }


    public class ImageRecord
    {
        public string? ImageUrl { get; set; }
    }

    public class UserResponsibility
    {
        public Guid UserId { get; set; }

        public string? UserName { get; set; }
    }

    public class UserRating
    {
        public string? SecurityCode { get; set; }
        public Guid userId { get; set; }

        public int Rating { get; set; }
        
        public string? Name { get; set; }
    }
  
    public class UserVoting
    {
        public string? SecurityCode { get; set; }
        public Guid userId { get; set; }
        public int VoteLevel { get; set; }
        public DateTime DateTime { get; set; }
        public string VoteType { get; set; } = null!;
    }



    public class RecordDetailResponseWithNotificationLog : RecordDetailResponse
    {
        public int CountAlarm { get; set; } = 0;
        public Level1Log Level1Log { get; set; } = null!;
        public Level2Log Level2Log { get; set; } = null!;
        public Level3Log Level3Log { get; set; } = null!;
        public Level4Log Level4Log { get; set; } = null!;
        public Level5Log Level5Log { get; set; } = null!;


    }


    public class Level1Log { 
        public List<Guid> userTakeNotification { get; set; }

        public int Count { get; set; }
    }

    public class Level2Log
    {
        public List<Guid> userTakeNotification { get; set; }

        public int Count { get; set; }
    }


    public class Level3Log
    {
        public List<Guid> userTakeNotification { get; set; }

        public int Count { get; set; }
    }

    public class Level4Log
    {
        public List<Guid> userTakeNotification { get; set; }

        public int Count { get; set; }
    }


    public class Level5Log
    {
        public List<Guid> userTakeNotification { get; set; }

        public int Count { get; set; }
    }
}
