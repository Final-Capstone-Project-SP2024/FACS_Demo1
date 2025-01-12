﻿using FireDetection.Backend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDetection.Backend.Domain.FluentAPIs
{
    public class MediaRecordConfiguration : IEntityTypeConfiguration<MediaRecord>
    {
        public void Configure(EntityTypeBuilder<MediaRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(book => book.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.MediaType).WithMany(x => x.MediaRecords).HasForeignKey(x => x.MediaTypeId);

            
        }
    }
}
