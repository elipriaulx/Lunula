using System;
using System.Drawing;

namespace Lunula.Core.Components
{
    public interface IActionerOld
    {
        Guid Id { get; }

        string Name { get; }
        string Description { get; }

        Image Icon { get; }
    }

    public interface IActionComponent<in T> : IActionerOld
    {
        Action<T> Operation { get; }
    }

    public interface IActionComponent<in T, out TO> : IActionerOld
    {
        Func<T, TO> Operation { get; }
    }
}