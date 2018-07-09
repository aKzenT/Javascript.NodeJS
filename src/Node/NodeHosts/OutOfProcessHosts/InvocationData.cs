﻿using Newtonsoft.Json;
using System.IO;

namespace Jering.JavascriptUtils.Node.NodeHosts.OutOfProcessHosts
{
    /// <summary>
    /// Invocation data to be sent to the Node.js process. 
    /// </summary>
    public class InvocationData
    {
        public InvocationData(string moduleSource,
            ModuleSourceType moduleSourceType,
            string newCacheIdentifier,
            string exportName,
            object[] args,
            Stream moduleStreamSource)
        {
            ModuleSource = moduleSource;
            ModuleSourceType = moduleSourceType;
            NewCacheIdentifier = newCacheIdentifier;
            ExportName = exportName;
            Args = args;
            ModuleStreamSource = moduleStreamSource;
        }

        /// <summary>
        /// Source of the module from which an export will be invoked. The source can be the path of the module (relative to the project directory),
        /// the module as a string or the cache identifier of the module.
        /// If <see cref="ModuleSourceType"/> is <see cref="ModuleSourceType.Stream"/>, this value must be null, otherwise it must be defined.
        /// </summary>
        public string ModuleSource { get; }

        /// <summary>
        /// The source type of the module from which an export will be invoked.
        /// </summary>
        public ModuleSourceType ModuleSourceType { get; }

        /// <summary>
        /// Node.js's caching key for the exports from the module for which an export will be invoked.
        /// If this identifier is not defined, the exports will not be cached.
        /// </summary>
        public string NewCacheIdentifier { get; }

        /// <summary>
        /// The name of the function to invoke. If this value is not defined, the module's exports object is assumed to be a function, and that function is invoked.
        /// </summary>
        public string ExportName { get; }

        /// <summary>
        /// The arguments for the invoked function.
        /// </summary>
        public object[] Args { get; }

        /// <summary>
        /// Stream containing the source of the module from which an export will be invoked.
        /// </summary>
        [JsonIgnore]
        public Stream ModuleStreamSource { get; }
    }
}
