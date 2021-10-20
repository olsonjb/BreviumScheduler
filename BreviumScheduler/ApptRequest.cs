using System;
using System.Collections.Generic;
using System.Text;

namespace BreviumScheduler
{
    class ApptRequest
    {
        int requestId;
        int personId;
        string[] preferredDays;
        int[] preferredDocs;
        bool isNew;

        public int RequestId { get => requestId; set => requestId = value; }
        public int PersonId { get => personId; set => personId = value; }
        public string[] PreferredDays { get => preferredDays; set => preferredDays = value; }
        public int[] PreferredDocs { get => preferredDocs; set => preferredDocs = value; }
        public bool IsNew { get => isNew; set => isNew = value; }

        public DateTime preferredDayAt(int index)
        {
            DateTime dateTime = DateTime.Parse(preferredDays[index]).ToUniversalTime();
            return dateTime;
        }
    }
}
