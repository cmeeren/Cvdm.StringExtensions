using System.Reflection;

[assembly: AssemblyMetadata("ImplicitNullability.AppliesTo", "InputParameters, RefParameters, OutParametersAndResult, Fields")]
[assembly: AssemblyMetadata("ImplicitNullability.Fields", "RestrictToReadonly")]
[assembly: AssemblyMetadata("ImplicitNullability.GeneratedCode", "Exclude")]

#if !FEATURE_ASSEMBLY_METADATA_ATTRIBUTE
// ReSharper disable CheckNamespace, UnusedParameter.Local, MissingXmlDoc
namespace System.Reflection
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal sealed class AssemblyMetadataAttribute : Attribute
    {
        public AssemblyMetadataAttribute(string key, string value)
        {
        }
    }
}
#endif