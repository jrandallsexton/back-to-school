using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Shared
{
    public record TestPoco(
        string id,
        string providerId,
        string externalId,
        string category,
        string name,
        int capacity,
        bool isGrass
    );
}
