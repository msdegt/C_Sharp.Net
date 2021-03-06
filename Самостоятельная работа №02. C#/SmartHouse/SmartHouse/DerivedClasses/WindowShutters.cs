﻿using System;

namespace SmartHouse
{
    public class WindowShutters : Device, IRateOfOpening, ITimeOfDayMode
    {
        private ShuttersMode statusMode; // режим

        public WindowShutters(bool status, bool statOp) : base(status)
        {
            StatusOpen = statOp;
        }

        public bool StatusOpen { get; set; }

        public void Open() // жалюзи открыты
        {
            if (StatusOpen == false)
            {
                StatusOpen = true;
            }
        }

        public void Close() // жалюзи закрыты
        {
            if (StatusOpen)
            {
                StatusOpen = false;
            }
        }

        public void SetMorningMode() // утренний режим
        {
            statusMode = ShuttersMode.MorningMode;

            if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour <= 17 && Status == false && StatusOpen == false)  
            {
                Status = true;
            }
            else if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour <= 17 && Status == false && StatusOpen)
            {
                StatusOpen = false;
                Status = true;
            }
        }
        
        public void SetEveningMode() // вечерний режим
        {
            statusMode = ShuttersMode.EveningMode;
            if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 5 && Status)
            {
                Status = false;
                if (StatusOpen)
                {                 
                    StatusOpen = false;
                }

            }
            else
            {
                if (StatusOpen)
                {
                    StatusOpen = false;
                }                
            }
        }       

        public override string ToString() 
        {
            string statusOpen;
            if (StatusOpen)
            {
                statusOpen = "жалюзи открыты";
            }
            else
            {
                statusOpen = "жалюзи закрыты";
            }

            string status;
            if (Status)
            {
                status = "жалюзи подняты";
            }
            else
            {
                status = "жалюзи опущены";
            }

            string mode = "";
            if (statusMode == ShuttersMode.MorningMode)
            {
                mode = "утренний";
            }
            else if (statusMode == ShuttersMode.EveningMode)
            {
                mode = "вечерний";
            }           

            return "Cостояние поднятия жалюзей: " + status + ", \nсостояние открытия жалюзей: " + statusOpen + ", режим: " + mode + "\n";
        }

    }
}
