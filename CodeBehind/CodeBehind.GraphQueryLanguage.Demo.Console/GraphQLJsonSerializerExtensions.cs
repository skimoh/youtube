//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQueryLanguage.Demo.Invocar
{
    public static class GraphQLJsonSerializerExtensions
    {
        public static TOptions New<TOptions>(this Action<TOptions> configure) =>
            configure.AndReturn(Activator.CreateInstance<TOptions>());

        public static TOptions AndReturn<TOptions>(this Action<TOptions> configure, TOptions options)
        {
            configure(options);
            return options;
        }
    }
}
