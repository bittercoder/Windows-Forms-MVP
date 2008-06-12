using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevDefined.Winforms.Framework.Commands;
using DevDefined.Winforms.Framework.Images;

namespace DevDefined.Winforms.Framework.Menus
{
    public class CommandMenuModel : MenuModelBase, IMenuModel
    {
        private readonly string _after;
        private readonly ICommand _command;
        private readonly string _imageName;
        private readonly bool _seperatorAbove;
        private readonly bool _seperatorBelow;

        public CommandMenuModel(ICommand command, string after, bool seperatorAbove, bool seperatorBelow,
                                string imageName)
        {
            _command = command;
            _after = after;
            _seperatorAbove = seperatorAbove;
            _seperatorBelow = seperatorBelow;
            _imageName = imageName;
        }

        #region IMenuModel Members

        public override IEnumerable<IMenuModel> Children
        {
            get { return new IMenuModel[] {}; }
        }

        public override string After
        {
            get { return _after; }
        }

        public override string Name
        {
            get { return _command.Name; }
        }

        public override ToolStripItem[] GetMenuItems(IImageFactory imageFactory)
        {
            var items = new List<ToolStripItem>();

            var item = new ToolStripMenuItem(_command.Text);
            item.Click += item_Click;

            if (!string.IsNullOrEmpty(_imageName))
            {
                item.Image = imageFactory.GetImageByUri(new Uri(_imageName));
            }

            if (_seperatorAbove) items.Add(new ToolStripSeparator());

            items.Add(item);

            if (_seperatorBelow) items.Add(new ToolStripSeparator());

            return items.ToArray();
        }

        #endregion

        private void item_Click(object sender, EventArgs e)
        {
            _command.Execute();
        }
    }
}