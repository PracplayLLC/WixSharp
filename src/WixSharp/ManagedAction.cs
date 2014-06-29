#region Licence...
/*
The MIT License (MIT)

Copyright (c) 2014 Oleg Shilo

Permission is hereby granted, 
free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion


namespace WixSharp
{
    /// <summary>
    /// Defines WiX Managed CustomAction. 
    /// <para>
    /// Managed CustomAction can be defined either in the Wix# script or in the external assembly or C# file.
    /// The only requirements for any C# method to be qualified for being Managed CustomAcyion is to 
    /// have DTF Action signature <c>public static ActionResult MyManagedAction(Session session)</c>, and be
    /// marked with <c>[CustomAction]</c> attribute.
    /// </para>
    /// <para>
    /// If Managed CustomAction depends on any assembly, which will not be registered with GAC on the 
    /// target system such assembly needs to be listed in the <see cref="ManagedAction.RefAssemblies"/>.
    /// </para>
    /// <remarks>
    /// <see cref="ManagedAction"/> often needs to be executed with the elevated privileges. Thus after instantiation it will have 
    /// <see cref="Action.Impersonate"/> set to <c>false</c> and <see cref="Action.Execute"/> set to <c>Execute.deferred</c> to allow elevating.
    /// </remarks>
    /// </summary>
    /// <example>The following is an example of using <c>MyManagedAction</c> method of the class 
    /// <c>CustomActions</c> as a Managed CustomAction.
    /// <code>
    /// class Script
    /// {
    ///     static public void Main(string[] args)
    ///     {
    ///         var project = 
    ///             new Project("My Product",
    ///     
    ///                 new Dir(@"%ProgramFiles%\My Company\My Product",
    ///         
    ///                     new File(@"AppFiles\MyApp.exe",
    ///                         new WixSharp.Shortcut("MyApp", @"%ProgramMenu%\My Company\My Product"),
    ///                         new WixSharp.Shortcut("MyApp", @"%Desktop%")),
    ///                 
    ///                     new File(@"AppFiles\Readme.txt"),
    ///             
    ///                 new ManagedAction(@"MyManagedAction"),
    ///         
    ///                 ...
    ///         
    ///         Compiler.BuildMsi(project);
    ///     }
    /// }
    /// 
    /// public class CustomActions
    /// {
    ///     [CustomAction]
    ///     public static ActionResult MyManagedAction(Session session)
    ///     {
    ///         MessageBox.Show("Hello World!", "Managed CA");
    ///         return ActionResult.Success;
    ///     }
    /// }
    /// </code>
    /// </example>
    public partial class ManagedAction : Action
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class.
        /// </summary>
        public ManagedAction()
        {
            Return = Return.check;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        public ManagedAction(string name)
            : base()
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
            Return = Return.check;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="id">The explicit <see cref="Id"></see> to be associated with <see cref="ManagedAction"/> instance.</param>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        public ManagedAction(Id id, string name)
            : base(id)
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
            Return = Return.check;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        /// <param name="actionAssembly">Path to the assembly containing the CustomAction implementation. Specify <c>"%this%"</c> if the assembly 
        /// is in the Wix# script.</param>
        public ManagedAction(string name, string actionAssembly)
            : base()
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
            ActionAssembly = actionAssembly;
            base.Return = Return.check;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="id">The explicit <see cref="Id"></see> to be associated with <see cref="ManagedAction"/> instance.</param>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        /// <param name="actionAssembly">Path to the assembly containing the CustomAction implementation. Specify <c>"%this%"</c> if the assembly 
        /// is in the Wix# script.</param>
        public ManagedAction(Id id, string name, string actionAssembly)
            : base(id)
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
            ActionAssembly = actionAssembly;
            base.Return = Return.check;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        /// <param name="returnType">The return type of the action.</param>
        /// <param name="when">The order of the action it should be executed with respect to the <see cref="Step"/> parameter.</param>
        /// <param name="step">The step the action should be executed during the installation.</param>
        /// <param name="condition">The launch condition for the <see cref="ManagedAction"/>.</param>
        public ManagedAction(string name, Return returnType, When when, Step step, Condition condition)
            : base(returnType, when, step, condition)
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        /// <param name="actionAssembly">Path to the assembly containing the CustomAction implementation. Specify <c>"%this%"</c> if the assembly 
        /// is in the Wix# script.</param>
        /// <param name="returnType">The return type of the action.</param>
        /// <param name="when">The order of the action it should be executed with respect to the <see cref="Step"/> parameter.</param>
        /// <param name="step">The step the action should be executed during the installation.</param>
        /// <param name="condition">The launch condition for the <see cref="ManagedAction"/>.</param>
        public ManagedAction(string name, string actionAssembly, Return returnType, When when, Step step, Condition condition)
            : base(returnType, when, step, condition)
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
            ActionAssembly = actionAssembly;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="id">The explicit <see cref="Id"></see> to be associated with <see cref="ManagedAction"/> instance.</param>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        /// <param name="returnType">The return type of the action.</param>
        /// <param name="when">The order of the action it should be executed with respect to the <see cref="Step"/> parameter.</param>
        /// <param name="step">The step the action should be executed during the installation.</param>
        /// <param name="condition">The launch condition for the <see cref="ManagedAction"/>.</param>
        public ManagedAction(Id id, string name, Return returnType, When when, Step step, Condition condition)
            : base(id, returnType, when, step, condition)
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="id">The explicit <see cref="Id"></see> to be associated with <see cref="ManagedAction"/> instance.</param>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        /// <param name="actionAssembly">Path to the assembly containing the CustomAction implementation. Specify <c>"%this%"</c> if the assembly 
        /// is in the Wix# script.</param>
        /// <param name="returnType">The return type of the action.</param>
        /// <param name="when">The order of the action it should be executed with respect to the <see cref="Step"/> parameter.</param>
        /// <param name="step">The step the action should be executed during the installation.</param>
        /// <param name="condition">The launch condition for the <see cref="ManagedAction"/>.</param>
        public ManagedAction(Id id, string name, string actionAssembly, Return returnType, When when, Step step, Condition condition)
            : base(id, returnType, when, step, condition)
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
            ActionAssembly = actionAssembly;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        /// <param name="returnType">The return type of the action.</param>
        /// <param name="when">The order of the action it should be executed with respect to the <see cref="Step"/> parameter.</param>
        /// <param name="step">The step the action should be executed during the installation.</param>
        /// <param name="condition">The launch condition for the <see cref="ManagedAction"/>.</param>
        /// <param name="sequence">The MSI sequence the action belongs to.</param>
        public ManagedAction(string name, Return returnType, When when, Step step, Condition condition, Sequence sequence)
            : base(returnType, when, step, condition, sequence)
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        /// <param name="actionAssembly">Path to the assembly containing the CustomAction implementation. Specify <c>"%this%"</c> if the assembly 
        /// is in the Wix# script.</param>
        /// <param name="returnType">The return type of the action.</param>
        /// <param name="when">The order of the action it should be executed with respect to the <see cref="Step"/> parameter.</param>
        /// <param name="step">The step the action should be executed during the installation.</param>
        /// <param name="condition">The launch condition for the <see cref="ManagedAction"/>.</param>
        /// <param name="sequence">The MSI sequence the action belongs to.</param>
        public ManagedAction(string name, string actionAssembly, Return returnType, When when, Step step, Condition condition, Sequence sequence)
            : base(returnType, when, step, condition, sequence)
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
            ActionAssembly = actionAssembly;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="id">The explicit <see cref="Id"></see> to be associated with <see cref="ManagedAction"/> instance.</param>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        /// <param name="returnType">The return type of the action.</param>
        /// <param name="when">The order of the action it should be executed with respect to the <see cref="Step"/> parameter.</param>
        /// <param name="step">The step the action should be executed during the installation.</param>
        /// <param name="condition">The launch condition for the <see cref="ManagedAction"/>.</param>
        /// <param name="sequence">The MSI sequence the action belongs to.</param>
        public ManagedAction(Id id, string name, Return returnType, When when, Step step, Condition condition, Sequence sequence)
            : base(id, returnType, when, step, condition, sequence)
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedAction"/> class with properties/fields initialized with specified parameters.
        /// </summary>
        /// <param name="id">The explicit <see cref="Id"></see> to be associated with <see cref="ManagedAction"/> instance.</param>
        /// <param name="name">Name of the CustomAction. The name should match the method implementing the custom action functionality.</param>
        /// <param name="actionAssembly">Path to the assembly containing the CustomAction implementation. Specify <c>"%this%"</c> if the assembly 
        /// is in the Wix# script.</param>
        /// <param name="returnType">The return type of the action.</param>
        /// <param name="when">The order of the action it should be executed with respect to the <see cref="Step"/> parameter.</param>
        /// <param name="step">The step the action should be executed during the installation.</param>
        /// <param name="condition">The launch condition for the <see cref="ManagedAction"/>.</param>
        /// <param name="sequence">The MSI sequence the action belongs to.</param>
        public ManagedAction(Id id, string name, string actionAssembly, Return returnType, When when, Step step, Condition condition, Sequence sequence)
            : base(id, returnType, when, step, condition, sequence)
        {
            Name = "Action" + (++count) + "_" + name;
            MethodName = name;
            ActionAssembly = actionAssembly;
        }

        /// <summary>
        /// Collection of path strings for dependency assemblies to be included in MSI. <c>RefAssemblies</c> should be used if the Managed CustomAction 
        /// depends on any assembly, which will not be registered with GAC on the target system.
        /// </summary>
        public string[] RefAssemblies = new string[0];
        /// <summary>
        /// Path to the assembly containing the CustomAction implementation. Specify <c>"%this%"</c> if the assembly 
        /// is in the Wix# script. 
        /// <para>Default value is <c>%this%</c>.</para>
        /// </summary>
        public string ActionAssembly = "%this%";
        /// <summary>
        /// Name of the method implementing the Managed CustomAction action functionality.
        /// </summary>
        public string MethodName = "";
    }

}
