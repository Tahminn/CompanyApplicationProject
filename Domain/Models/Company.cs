﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Company: BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
