using EXSYS.DAL.DTO.Response;
using EXSYS.DAL.Model;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.BLL.Mapping
{
    public static class MapsterConfig
    {
        public static void MapesterConfigRegister()
        {
            TypeAdapterConfig<Course, CourseResponse>.NewConfig()
                .Map(des => des.Course_Id, src => src.Id)

                .Map(dest => dest.UserCreated, src => src.CreatedBy.UserName);

            TypeAdapterConfig<Question, QuestionResponse>
             .NewConfig()
             .Map(dest => dest.CourseName,
                  src => src.Course.Name);

                }
    }
}
