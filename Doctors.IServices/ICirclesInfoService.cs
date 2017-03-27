using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctors.Model;

namespace Doctors.IServices
{
    public interface ICirclesInfoService
    {
        IList<CirclesInfoModel> GetCirclesInfo(int pageIndex, int pageSize, string city, string dep);
        IList<CirclecommentModel> GetCommentsInfo(string circleId);
    }
}
