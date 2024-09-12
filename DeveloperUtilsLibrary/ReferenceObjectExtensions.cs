using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model.Desktop;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.Model.Search;
using TFlex.DOCs.Model.Structure;
using TFlex.PdmFramework.Nomenclature;

namespace DeveloperUtilsLibrary
{
    public static class ReferenceObjectExtensions
    {
        /// <summary>
        /// Начать редактировать объект
        /// </summary>
        /// <param name="ro"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void StartUpdate(this ReferenceObject ro)
        {
            if (ro.IsCheckedOut && !ro.IsCheckedOutByCurrentUser)
                throw new InvalidOperationException(String.Format(TFlex.DOCs.Resources.Strings.Messages.CantCheckOutExceptionMessage, ro));

            if (ro.CanCheckOut)
                Desktop.CheckOut(ro, false);

            if (!ro.Changing)
                ro.BeginChanges();
        }
        /// <summary>
        /// Сохранить изменения объекта
        /// </summary>
        /// <param name="ro"></param>
        /// <param name="comment"></param>
        public static void EndUpdate(this ReferenceObject ro, string comment)
        {
            if (ro.Changing)
                ro.EndChanges();

            if (ro.CanCheckIn)
                Desktop.CheckIn(ro, comment, false);
        }
        /// <summary>
        /// Отменить изменения объекта
        /// </summary>
        /// <param name="ro"></param>
        public static void CancelUpdate(this ReferenceObject ro)
        {
            if (ro.Changing)
                ro.CancelChanges();

            if (ro.CanUndoCheckOut)
                Desktop.UndoCheckOut(ro);
        }
        /// <summary>
        /// Возвращается список ревизий объекта
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<ReferenceObject> GetAllRevision(this ReferenceObject obj)
        {
            List<ReferenceObject> listRevisions;
            Guid revisionLogicalGuid = obj.SystemFields.LogicalObjectGuid;
            Reference currentReference = obj.Reference;
            try
            {
                listRevisions = new List<ReferenceObject>();
                currentReference.LoadSettings.UseConfigurationSettings = false;
                listRevisions = currentReference.Find(currentReference.ParameterGroup[SystemParameterType.LogicalObjectGuid], ComparisonOperator.Equal, revisionLogicalGuid);
            }
            finally
            {
                currentReference.LoadSettings.UseConfigurationSettings = true;
            }
            return listRevisions;
        }
    }
}
