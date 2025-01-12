﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDetection.Backend.Domain.DTOs.Response
{
    public class CameraInformationResponse
    {
        public Guid CameraId { get; set; }
        public string Status { get; set; } = null!;
        public string CameraName { get; set; } = null!;
        public string CameraDestination { get; set; } = null!;
        public string CameraImage { get;set; } = null!;
        public string LocationName { get; set; } = null!;
    }

    public class CameraInformationDetailResponse : CameraInformationResponse
    {
        public int RecordCount { get; set; }

    }
}
