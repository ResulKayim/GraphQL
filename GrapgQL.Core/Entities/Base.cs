﻿using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapgQL.Core.Entities
{
    public class Base
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
    }
}
