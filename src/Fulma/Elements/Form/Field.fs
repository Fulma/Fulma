namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Field =

    module Classes =
        let [<Literal>] Container = "field"
        let [<Literal>] Body = "field-body"
        module Label =
            let [<Literal>] Container = "field-label"
            module VerticalAlign =
                  let [<Literal>] IsNormal = "is-normal"
        module HasAddons =
              let [<Literal>] Left = "has-addons"
              let [<Literal>] Centered = "has-addons-centered"
              let [<Literal>] Right = "has-addons-right"
              let [<Literal>] FullWidh = "has-addons-fullwidth"
        module IsGrouped =
              let [<Literal>] Left = "is-grouped"
              let [<Literal>] Centered = "is-grouped-centered"
              let [<Literal>] Right = "is-grouped-right"
              let [<Literal>] Multiline = "is-grouped-multiline"
        module Layout =
            let [<Literal>] IsHorizontal = "is-horizontal"

    type Option =
        /// Add `has-addons` class
        | HasAddons
        /// Add `has-addons-centered` class
        | HasAddonsCentered
        /// Add `has-addons-right` class
        | HasAddonsRight
        /// Add `has-addons-fullwidth` class
        | HasAddonsFullWidth
        /// Add `is-grouped` class
        | IsGrouped
        /// Add `is-grouped-centered` class
        | IsGroupedCentered
        /// Add `is-grouped-right` class
        | IsGroupedRight
        /// Add `is-grouped-multiline` class
        | IsGroupedMultiline
        /// Add `is-horizontal` class
        | IsHorizontal
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { HasAddons : string option
          IsGrouped : string option
          Layout : string option
          CustomClass : string option
          Props : IHTMLProp list
          Modifiers : string option list }
        static member Empty =
            { HasAddons = None
              IsGrouped = None
              Layout = None
              CustomClass = None
              Props = []
              Modifiers = [] }

    module Label =

        type Option =
            | Size of ISize
            | IsNormal
            | CustomClass of string
            | Props of IHTMLProp list
            | Modifiers of Modifier.IModifier list

        type internal Options =
            { Size : string option
              CustomClass : string option
              Props : IHTMLProp list
              Modifiers : string option list }
            static member Empty =
                { Size = None
                  CustomClass = None
                  Props = []
                  Modifiers = [] }

    /// Generate <label class="field-label"></label>
    let label options children =
        let parseOptions (result : Label.Options) =
            function
            | Label.Size size -> { result with Size = ofSize size |> Some }
            | Label.IsNormal -> { result with Size = Classes.Label.VerticalAlign.IsNormal |> Some }
            | Label.CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Label.Props props -> { result with Props = props }
            | Label.Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Label.Options.Empty
        let classes = Helpers.classes
                        Classes.Label.Container
                        ( opts.Size::opts.CustomClass::opts.Modifiers )
                        [ ]
        div (classes::opts.Props)
            children

    /// Generate <label class="field-body"></label>
    let body (options : GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Body ( opts.CustomClass::opts.Modifiers ) []
        div (classes::opts.Props) children

    let internal fieldView element options children =
        let parseOptions (result : Options) =
            function
            | HasAddons -> { result with HasAddons = Classes.HasAddons.Left |> Some }
            | HasAddonsCentered -> { result with HasAddons = Classes.HasAddons.Left + " " + Classes.HasAddons.Centered |> Some }
            | HasAddonsRight -> { result with HasAddons = Classes.HasAddons.Left + " " + Classes.HasAddons.Right |> Some }
            | HasAddonsFullWidth -> { result with HasAddons = Classes.HasAddons.Left + " " + Classes.HasAddons.FullWidh |> Some }
            | IsGrouped -> { result with IsGrouped = Classes.IsGrouped.Left |> Some }
            | IsGroupedCentered -> { result with IsGrouped = Classes.IsGrouped.Left + " " + Classes.IsGrouped.Centered |> Some }
            | IsGroupedRight -> { result with IsGrouped = Classes.IsGrouped.Left + " " + Classes.IsGrouped.Right |> Some }
            | IsGroupedMultiline -> { result with IsGrouped = Classes.IsGrouped.Left + " " + Classes.IsGrouped.Multiline |> Some }
            | IsHorizontal -> { result with Layout = Classes.Layout.IsHorizontal |> Some }
            | Option.CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Option.Props props -> { result with Props = props }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        ( opts.HasAddons
                          ::opts.IsGrouped
                          ::opts.Layout
                          ::opts.CustomClass
                          ::opts.Modifiers )
                        [ ]

        element (classes::opts.Props)
            children

    /// Generate <div class="field"></div>
    let div x y = fieldView div x y
    /// Generate <p class="field"></p>
    let p x y = fieldView p x y
