#pragma warning disable SA1633 // File should have header
using System.Runtime.CompilerServices;
#pragma warning restore SA1633 // File should have header
using System.Runtime.InteropServices;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("330c823a-15c5-404e-8939-f478f3a4ee30")]

[assembly: InternalsVisibleTo("ProductIngestionTypesTest")]
