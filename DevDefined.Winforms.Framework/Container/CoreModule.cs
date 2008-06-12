using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DevDefined.Winforms.Framework.Commands;
using DevDefined.Winforms.Framework.Content;
using DevDefined.Winforms.Framework.Content.Output;
using DevDefined.Winforms.Framework.Content.ProjectExplorer;
using DevDefined.Winforms.Framework.Content.PropertyGrid;
using DevDefined.Winforms.Framework.Content.ToolBox;
using DevDefined.Winforms.Framework.Docking;
using DevDefined.Winforms.Framework.EventPublisher;
using DevDefined.Winforms.Framework.Images;
using DevDefined.Winforms.Framework.Menus;
using DevDefined.Winforms.Framework.Shell;

namespace DevDefined.Winforms.Framework.Container
{
    public class CoreModule : IModule
    {
        public const string MainMenuToolStripKey = "menus.topMenuStrip";

        #region IModule Members

        public void Install(IWindsorContainer container)
        {
            container.AddFacility<EventPublisherFacility>();
            container.AddFacility<StartableFacility>();
            container.AddFacility<DockingFacility>();
            container.AddFacility<MenuFacility>();

            container.AddComponent("applicationShell", typeof (IApplicationShell), typeof (ApplicationShell));
            
            container.AddComponent("presenter.factory", typeof (IPresenterFactory), typeof (PresenterFactory));

            container.Register(
                Component.For<IImageSource>().ImplementedBy<ResourceManagerImageSource>().Named("imageSource.res"));
            
            container.Register(
                Component.For<IImageFactory>()
                    .ImplementedBy<ImageFactory>()
                    .ServiceOverrides(
                    ServiceOverride.ForKey("sources").Eq<IImageSource>("imageSource.res")));

            // todo: refactor to register all views and presenters declaratively.
            container.Register(
                Component.For<IOutputView>().ImplementedBy<OutputView>(),
                Component.For<IOutputPresenter>().ImplementedBy<OutputPresenter>(),
                Component.For<IProjectExplorerView>().ImplementedBy<ProjectExplorerView>(),
                Component.For<IProjectExplorerPresenter>().ImplementedBy<ProjectExplorerPresenter>(),
                Component.For<IPropertyGridView>().ImplementedBy<PropertyGridView>(),
                Component.For<IPropertyGridPresenter>().ImplementedBy<PropertyGridPresenter>(),
                Component.For<IToolBoxView>().ImplementedBy<ToolBoxView>(),
                Component.For<IToolBoxPresenter>().ImplementedBy<ToolBoxPresenter>());

            container.Register(
                Component
                    .For<IMenuPresenter>()
                    .ImplementedBy<MenuStripPresenter>()
                    .Parameters(
                    Parameter
                        .ForKey("menu")
                        .Eq("${" + MainMenuToolStripKey + "}")));

            container.Register(AllTypes.Of<AbstractCommand>().FromAssembly(typeof (AbstractCommand).Assembly));

            container.Register(
                Component.For<DockedWindowsMenuModel>());
        }

        #endregion
    }
}