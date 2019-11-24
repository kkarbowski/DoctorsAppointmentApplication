﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppointmentApi {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Config {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Config() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AppointmentApi.Config", typeof(Config).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Database/DoctorsAppointmentDatabase/DoctorsAppointment.db.
        /// </summary>
        public static string DbPath {
            get {
                return ResourceManager.GetString("DbPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 36260991567323964782201347.
        /// </summary>
        public static string JwtSecret {
            get {
                return ResourceManager.GetString("JwtSecret", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Doctor Appointments Api.
        /// </summary>
        public static string SwaggerApiTitle {
            get {
                return ResourceManager.GetString("SwaggerApiTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /swagger/v1/swagger.json.
        /// </summary>
        public static string SwaggerApiUrl {
            get {
                return ResourceManager.GetString("SwaggerApiUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to v1.
        /// </summary>
        public static string SwaggerApiVersion {
            get {
                return ResourceManager.GetString("SwaggerApiVersion", resourceCulture);
            }
        }
    }
}
