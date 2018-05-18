using System.Runtime.InteropServices.ComTypes;
using Hris.Common.Business.Domains;
using Hris.Database.Entities;
using Hris.Database.Entities.Common;

namespace Hris.Common.Persistence.Transformations
{
    public static class FunctionTransformations
    {
        public static MDAction Transform(this Action action)
        {
            return action == null
                ? null
                : new MDAction
                {
                    Id = action.Id,
                    Status = action.Status.Transform(),
                    Event = action.Event,
                    Key = action.Event,
                    Name = action.Name,
                    Order = action.Order,
                    Icon = action.Icon
                };
        }

        public static Action Transform(this MDAction action)
        {
            return action == null
                ? null
                : new Action(action.Id, action.Key, action.Icon, action.Name, action.Event, action.Order, action.Status.Transform());
        }

        public static void UpdateValue(this MDAction action, Action value)
        {
            if (value == null) return;
            if (action == null) action = new MDAction {Id = value.Id};

            action.Status = value.Status.Transform();
            action.Event = value.Event;
            action.Key = value.Key;
            action.Name = value.Name;
            action.Order = value.Order;
            action.Icon = value.Icon;
        }

        public static MDFunction Transform(this Function function)
        {
            return function == null
                ? null
                : new MDFunction
                {
                    Id = function.Id,
                    Status = function.Status.Transform(),
                    Icon = function.Icon,
                    Key = function.Key,
                    Name = function.Name,
                    OrderIndex = function.OrderIndex,
                    Module = function.Module.Transform()
                };
        }

        public static Function Transform(this MDFunction function)
        {
            return function == null
                ? null
                : new Function(function.Id, function.Name, function.Module.Transform(), function.Key, function.Icon,
                    function.OrderIndex, function.Status.Transform());
        }

        public static void UpdateValue(this MDFunction function, Function value)
        {
            if (value == null) return;
            if (function == null) function = new MDFunction {Id = value.Id};

            function.Status = value.Status.Transform();
            function.Icon = value.Icon;
            function.Key = value.Key;
            function.Module = value.Module.Transform();
            function.Name = value.Name;
            function.OrderIndex = value.OrderIndex;
        }
    }
}
