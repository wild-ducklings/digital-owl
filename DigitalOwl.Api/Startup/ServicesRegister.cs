using DigitalOwl.Service.Interface;
using DigitalOwl.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalOwl.Api.Startup
{
    /// <summary>
    /// Class register Services to Api
    /// </summary>
    public class ServicesRegister
    {
        /// <summary>
        /// Method register Services to Api
        /// </summary>
        /// <param name="services"></param>
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupRoleService, GroupRoleService>();
            services.AddScoped<IGroupMemberService, GroupMemberService>();
            services.AddScoped<IGroupMessageService, GroupMessageService>();
            services.AddScoped<IPollService, PollService>();
            services.AddScoped<IPollQuestionService, PollQuestionService>();
            services.AddScoped<IPollAnswerService, PollAnswerService>();
        }
    }
}