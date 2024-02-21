using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.Model.Stages;

namespace DeveloperUtilsLibrary
{
    public class StageController
    {
        private ServerConnection connection;

        public StageController(ServerConnection connection)
        {
            this.connection = connection;
        }

        public List<ReferenceObject> ChangeStage(Guid stageGuid, List<ReferenceObject> objects)
        {
            if (!objects.Any())
                return new List<ReferenceObject>(0);

            var stage = Stage.Find(connection, stageGuid);
            if (stage is null)
                return new List<ReferenceObject>(0);

            return stage.Set(objects);
        }
    }

    public static class StageGuids
    {
        public static readonly Guid Разработка = new Guid("527f5234-4c94-43d1-a38d-d3d7fd5d15af");
        public static readonly Guid Корректировка = new Guid("18df455a-0dc8-43a9-b256-c0fd6898df1b");
        public static readonly Guid Хранение = new Guid("9826e84a-a0a7-404b-bf0e-d61b902e346a");
        public static readonly Guid Исправление = new Guid("006dfe49-78c6-453d-a65d-c02b24fc4f98");
        public static readonly Guid Утверждено = new Guid("a5ea2e1c-d441-42fd-8f92-49840351d6c1");
        public static readonly Guid ГотовоКПрименению = new Guid("e915db7f-aeb6-4127-a372-608849570413");
        public static readonly Guid Согласовано = new Guid("c89e6ee8-f060-4091-b576-00025be0846a");
        public static readonly Guid Аннулировано = new Guid("b04183e6-decb-47b3-8b46-b75a6548d573");
        public static readonly Guid Согласование = new Guid("8005ee9d-3769-440f-9bfc-fad2adeae3af");
        public static readonly Guid Утверждение = new Guid("a3471b72-32e9-4669-a4b8-0fcafcfc3eb6");
        public static readonly Guid Нормоконтроль = new Guid("3442cf1a-9f8b-4b7d-96de-01a5636d90fb");
    }
}
