using System;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Docking
{
    public interface IDockingController
    {
        IEnumerable<IPresenter> Presenters { get; }
        void ArrangeInDefaultLayout();
        void ShowPresenterDocked(Type presenterType, DockState state);

        void ShowPresenterDockedInsidePanel(Type presenterType, Type panelPresenterType, DockAlignment alignment,
                                            float size);

        void Hide(Type presenterType);
        bool IsVisible(IPresenter presenter);
    }
}