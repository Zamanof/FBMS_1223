using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_MANAGER_SERVER;
public class Command
{
    public const string ProcessList = "PROCLIST";
    public const string Kill = "KILL";
    public const string Run = "RUN";
    public string? Text { get; set; }
    public string? Param { get; set; }

}
