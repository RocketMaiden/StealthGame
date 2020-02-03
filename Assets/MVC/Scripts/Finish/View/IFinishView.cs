using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MVC.Scripts.Finish.View
{
    public interface IFinishView
    {
        event Action SomethingTouchedFinish;
    }
}
