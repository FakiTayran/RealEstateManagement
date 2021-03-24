using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyLibraryProject.Configuration.Dto;

namespace MyLibraryProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyLibraryProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
