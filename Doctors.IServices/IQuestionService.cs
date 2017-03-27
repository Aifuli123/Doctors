using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctors.Model;

namespace Doctors.IServices
{
    public interface IQuestionService
    {
        int QuestionAdd(QuestionModel question);
    }
}
