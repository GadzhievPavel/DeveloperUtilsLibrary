using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model.Desktop;
using TFlex.DOCs.Model.References;

namespace DeveloperUtilsLibrary
{
    public static class ReferenceObjectExtensions
    {
        public static void StartUpdate(this ReferenceObject ro)
        {
            if (ro.IsCheckedOut && !ro.IsCheckedOutByCurrentUser)
                throw new InvalidOperationException(String.Format(TFlex.DOCs.Resources.Strings.Messages.CantCheckOutExceptionMessage, ro));

            if (ro.CanCheckOut)
                Desktop.CheckOut(ro, false);

            if (!ro.Changing)
                ro.BeginChanges();
        }

        public static void EndUpdate(this ReferenceObject ro, string comment)
        {
            if (ro.Changing)
                ro.EndChanges();

            if (ro.CanCheckIn)
                Desktop.CheckIn(ro, comment, false);
        }

        public static void CancelUpdate(this ReferenceObject ro)
        {
            if (ro.Changing)
                ro.CancelChanges();

            if (ro.CanUndoCheckOut)
                Desktop.UndoCheckOut(ro);
        }
    }
}
