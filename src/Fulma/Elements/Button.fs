namespace Fulma

open Fulma
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Button =

    module Classes =
        let [<Literal>] Container = "button"
        module State =
              let [<Literal>] IsHovered = "is-hovered"
              let [<Literal>] IsFocused = "is-focus"
              let [<Literal>] IsActive = "is-active"
              let [<Literal>] IsLoading = "is-loading"
              let [<Literal>] IsStatic = "is-static"
        module Styles =
            let [<Literal>] IsFullwidth = "is-fullwidth"
            let [<Literal>] IsLink = "is-link"
            let [<Literal>] IsOutlined = "is-outlined"
            let [<Literal>] IsInverted = "is-inverted"
            let [<Literal>] IsText = "is-text"
            let [<Literal>] IsRounded = "is-rounded"
            let [<Literal>] IsExpanded = "is-expanded"
        module List =
            let [<Literal>] Container = "buttons"
            let [<Literal>] HasAddons = "has-addons"
            let [<Literal>] IsCentered = "is-centered"
            let [<Literal>] IsRight = "is-right"

    type Option =
        // Colors
        | Color of IColor
        | Size of ISize
        /// Add `is-fullwidth` class
        | IsFullWidth
        /// Add `is-link` class
        | IsLink
        /// Add `is-outlined` class
        | IsOutlined
        /// Add `is-inverted` class
        | IsInverted
        /// Add `is-text` class
        | IsText
        /// Add `is-rouned` class
        | IsRounded
        /// Add `is-expanded` class
        | IsExpanded
        /// Add `is-hovered` class if true
        | IsHovered of bool
        /// Add `is-focused` class if true
        | IsFocused of bool
        /// Add `is-active` class if true
        | IsActive of bool
        /// Add `is-loading` class if true
        | IsLoading of bool
        /// Add `is-static` class if true
        | IsStatic of bool
        /// Add `disabled` HTMLAttr if true
        | Disabled of bool
        | Props of IHTMLProp list
        | OnClick of (MouseEvent -> unit)
        | CustomClass of string

    type internal Options =
        { Level : string option
          Size : string option
          IsOutlined : bool
          IsInverted : bool
          IsDisabled : bool
          IsHovered : bool
          IsFocused : bool
          IsExpanded : bool
          IsText : bool
          IsRounded : bool
          IsActive : bool
          IsLoading : bool
          IsStatic : bool
          Props : IHTMLProp list
          CustomClass : string option
          OnClick : (MouseEvent -> unit) option }
        static member Empty =
            { Level = None
              Size = None
              IsOutlined = false
              IsInverted = false
              IsDisabled = false
              IsText = false
              IsRounded = false
              IsActive = false
              IsExpanded = false
              IsLoading = false
              IsStatic = false
              IsHovered = false
              IsFocused = false
              Props = []
              CustomClass = None
              OnClick = None }

    let internal btnView element (options : Option list) children =
        let parseOption (result : Options) opt =
            match opt with
            | Color color -> { result with Level = ofColor color |> Some }
            // Sizes
            | Size size -> { result with Size = ofSize size |> Some }
            // Styles
            | IsFullWidth -> { result with Size = Classes.Styles.IsFullwidth  |> Some }
            | IsLink -> { result with Level = Classes.Styles.IsLink |> Some }
            | IsOutlined -> { result with IsOutlined = true }
            | IsInverted -> { result with IsInverted = true }
            | IsText -> { result with IsText = true }
            | IsRounded -> { result with IsRounded = true }
            | IsExpanded -> { result with IsExpanded = true }
            // States
            | IsHovered state -> { result with IsHovered = state }
            | IsFocused state -> { result with IsFocused = state }
            | IsActive state -> { result with IsActive = state }
            | IsLoading state -> { result with IsLoading = state }
            | IsStatic state -> { result with IsStatic = state }
            | Disabled isDisabled -> { result with IsDisabled = isDisabled }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | OnClick cb -> { result with OnClick = cb |> Some }

        let opts = options |> List.fold parseOption Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ opts.Level
                          opts.Size
                          opts.CustomClass ]
                        [ Classes.Styles.IsOutlined, opts.IsOutlined
                          Classes.Styles.IsInverted, opts.IsInverted
                          Classes.Styles.IsText, opts.IsText
                          Classes.Styles.IsRounded, opts.IsRounded
                          Classes.Styles.IsExpanded, opts.IsExpanded
                          Classes.State.IsHovered, opts.IsHovered
                          Classes.State.IsFocused, opts.IsFocused
                          Classes.State.IsActive, opts.IsActive
                          Classes.State.IsLoading, opts.IsLoading
                          Classes.State.IsStatic, opts.IsStatic ]

        element
            [ yield classes
              yield Fable.Helpers.React.Props.Disabled opts.IsDisabled :> IHTMLProp
              if Option.isSome opts.OnClick then
                yield DOMAttr.OnClick opts.OnClick.Value :> IHTMLProp
              yield! opts.Props ]
            children

    /// Generate <button class="button"></button>
    let button options children = btnView button options children
    /// Generate <span class="button"></span>
    let span options children = btnView span options children
    /// Generate <a class="button"></a>
    let a options children = btnView a options children

    module Input =
        let internal btnInput typ options =
            let hasProps =
                options
                |> List.exists (fun opts ->
                    match opts with
                    | Props _ -> true
                    | _ -> false
                )

            if hasProps then
                let newOptions =
                    options
                    |> List.map (fun opts ->
                        match opts with
                        | Props props -> Props ((Type typ :> IHTMLProp) ::props)
                        | forward -> forward
                    )
                btnView (fun options _ -> input options) newOptions [ ]

            else
                btnView (fun options _ -> input options) ((Props [ Type typ ])::options) [ ]

        /// Generate <input type="reset" class="button" />
        let reset options = btnInput "reset" options
        /// Generate <input type="submit" class="button" />
        let submit options = btnInput "submit" options

    module List =

        type Option =
            | HasAddons
            | IsCentered
            | IsRight
            | Props of IHTMLProp list
            | CustomClass of string

        type internal Options =
            { HasAddons : bool
              IsCentered : bool
              IsRight : bool
              Props : IHTMLProp list
              CustomClass : string option }

            static member Empty =
                { HasAddons = false
                  IsCentered = false
                  IsRight = false
                  Props = [ ]
                  CustomClass = None }

    /// Generate <div class="buttons"></div>
    let list (options : List.Option list) children =
        let parseOption (result : List.Options) opt =
            match opt with
            | List.HasAddons -> { result with HasAddons = true }
            | List.IsCentered -> { result with IsCentered = true }
            | List.IsRight -> { result with IsRight = true }
            | List.Props props -> { result with Props = props }
            | List.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOption List.Options.Empty
        let classes = Helpers.classes
                        Classes.List.Container
                        [ opts.CustomClass ]
                        [ Classes.List.HasAddons, opts.HasAddons
                          Classes.List.IsCentered, opts.IsCentered
                          Classes.List.IsRight, opts.IsRight ]

        div (classes::opts.Props) children
