using Blazor.Server.UI.Models.SideMenu;
using CleanArchitecture.Blazor.Infrastructure.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor;

namespace Blazor.Server.UI.Services.Navigation;

public class MenuService : IMenuService
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    public MenuService(RoleManager<ApplicationRole> roleManager)
    {
        _roleManager = roleManager;
    }
    private readonly List<MenuSectionModel> _features = new List<MenuSectionModel>()
    {        
        new MenuSectionModel
        {
            Title = "Application",
            SectionItems = new List<MenuSectionItemModel>
            {
                new()
                {
                    Title = "Home",
                    Icon = Icons.Material.Filled.Home,
                    Href = "/"
                },
                new()
                {
                    Title = "Dashboard",
                    Icon = Icons.Material.Filled.Dashboard,
                    Href = "/investor/dashboard",
                    Roles = new string[]{"Basic"},
                    PageStatus = PageStatus.Completed
                },
                new()
                {
                    Title = "Investments",
                    Icon = Icons.Material.Filled.Analytics,
                    Href = "/investor/investments",
                    Roles = new string[]{"Basic"},
                    PageStatus = PageStatus.Completed
                },
                new()
                {
                    Title = "Wallet",
                    Icon = Icons.Material.Filled.AccountBalanceWallet,
                    Href = "/investor/wallet",
                    Roles = new string[]{"Basic"},
                    PageStatus = PageStatus.Completed
                },
                new()
                {
                    Title = "Support",
                    Icon = Icons.Material.Filled.Money,
                    Href = "/support/investments",
                    Roles= new string[]{"Admin"},
                    PageStatus = PageStatus.Completed
                },
                new()
                {
                    Title = "E-Commerce",
                    Icon = Icons.Material.Filled.ShoppingCart,
                    PageStatus = PageStatus.Completed,
                    IsParent = true,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {
                        new(){
                             Title = "Products",
                             Href = "/pages/products",
                             Roles = new string[]{"Basic"},
                             PageStatus = PageStatus.Completed,
                        },
                        new(){
                             Title = "Customers",
                             Href = "/pages/customers",
                             Roles = new string[] {"Admin"},
                             PageStatus = PageStatus.Completed,
                        }
                    }
                },
                new()
                {
                    Title = "Analytics",
                    Icon = Icons.Material.Filled.Analytics,
                    Href = "/analytics",
                    PageStatus = PageStatus.ComingSoon
                },
                new()
                {
                    Title = "Banking",
                    Icon = Icons.Material.Filled.Money,
                    Href = "/banking",
                    PageStatus = PageStatus.ComingSoon
                },
                new()
                {
                    Title = "Booking",
                    Icon = Icons.Material.Filled.CalendarToday,
                    Href = "/booking",
                    PageStatus = PageStatus.ComingSoon
                }
            }
        },

        new MenuSectionModel
        {
            Title = "MANAGEMENT",
            SectionItems = new List<MenuSectionItemModel>
            {
                new()
                {
                    IsParent = true,
                    Title = "Authorization",
                    Icon = Icons.Material.Filled.Person,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {
                        new()
                        {
                            Title = "Users",
                            Href = "/indentity/users",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Roles",
                            Href = "/indentity/roles",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Profile",
                            Href = "/user/profile",
                            PageStatus = PageStatus.Completed
                        }
                    }
                },
                new()
                {
                    IsParent = true,
                    Title = "System",
                    Icon = Icons.Material.Filled.Devices,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {   new()
                        {
                            Title = "Dictionaries",
                            Href = "/system/dictionaries",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Audit Trails",
                            Href = "/system/audittrails",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Log",
                            Href = "/system/logs",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Jobs",
                            Href = "/hangfire/index",
                            PageStatus = PageStatus.ComingSoon
                        }
                    }
                }

            }
        }
    };
    

    public IEnumerable<MenuSectionModel> Features => _features;
}
