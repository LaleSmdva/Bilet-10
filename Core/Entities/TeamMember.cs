﻿using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class TeamMember : IEntity
{
    public int Id { get ; set ; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public string? Image { get; set; }
}
