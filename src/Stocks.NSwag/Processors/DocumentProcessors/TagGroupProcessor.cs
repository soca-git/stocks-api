using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;
using Stocks.NSwag.Utils;
using Stocks.Shared.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Stocks.NSwag.Processors.DocumentProcessors
{
    internal class TagGroupProcessor : IDocumentProcessor
    {
        private readonly Assembly _controllerAssembly; 

        public TagGroupProcessor(Assembly controllerAssembly)
        {
            _controllerAssembly = controllerAssembly;
        }

        public void Process(DocumentProcessorContext context)
        {
            context.Document.ExtensionData.Add("x-tagGroups", GetTagGroups());
        }

        private List<TagGroup> GetTagGroups()
        {
            var controllers = _controllerAssembly
                .GetExportedTypes()
                .Where(controller => controller.IsSubclassOf(typeof(ControllerBase)));

            var tagGroups = new Dictionary<string, TagGroup>();
            controllers.ForEach(controller => {
                string tagGroup = controller.Namespace.GetTagGroup();
                string tag = controller.Namespace.GetTag();

                if (!tagGroups.ContainsKey(tagGroup))
                {
                    tagGroups.Add(tagGroup, new TagGroup(tagGroup));
                }

                tagGroups[tagGroup].AddTag(tag);
            });

            return tagGroups.Values.ToList();
        }

        internal class TagGroup
        {
            public TagGroup(string name)
            {
                Name = name;
                Tags = new List<string>();
            }

            public TagGroup AddTag(string name)
            {
                if (!Tags.Contains(name))
                {
                    Tags.Add(name);
                }

                return this;
            }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }
        }
    }
}
