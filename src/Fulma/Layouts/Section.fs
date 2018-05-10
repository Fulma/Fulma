namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Section =

    module Classes =
        let [<Literal>] Container = "section"
        module Spacing =
            let [<Literal>] IsMedium = "is-medium"
            let [<Literal>] IsLarge = "is-large"

    type Option =
        | Props of IHTMLProp list
        | CustomClass of string
        /// Add `is-medium` class
        | IsMedium
        /// Add `is-large` class
        | IsLarge
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { Props : IHTMLProp list
          CustomClass : string option
          Spacing : string option
          Modifiers : string option list }

        static member Empty =
            { Props = []
              CustomClass = None
              Spacing = None
              Modifiers = [] }

    /// Generate <section class="section"></section>
    let section (options: Option list) children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | IsMedium -> { result with Spacing = Classes.Spacing.IsMedium |> Some }
            | IsLarge -> { result with Spacing = Classes.Spacing.IsLarge |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes =
            Helpers.classes
                Classes.Container
                ( opts.CustomClass::opts.Spacing::opts.Modifiers )
                [ ]

        section (classes::opts.Props) children
