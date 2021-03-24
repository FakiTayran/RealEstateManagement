using System.Threading.Tasks;
using MyLibraryProject.Configuration.Dto;

namespace MyLibraryProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
