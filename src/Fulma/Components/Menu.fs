namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Menu =
    module Types =
        module Item =
            type Option =
                | IsActive
                | Props of IHTMLProp list
                | CustomClass of string
                | OnClick of (React.MouseEvent -> unit)

            type Options =
                {   Props : IHTMLProp list
                    IsActive : bool
                    CustomClass : string option
                    OnClick : (React.MouseEvent -> unit) option }
                static member Empty =
                    { Props = []
                      IsActive = false
                      CustomClass = None
                      OnClick = None }

    open Types

    let menu (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Menu.Container [opts.CustomClass] []
        aside (class'::opts.Props) children

    let label (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Menu.Label [opts.CustomClass] []
        p (class'::opts.Props) children

    let list (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Menu.List [opts.CustomClass] []
        ul (class'::opts.Props) children

    module Item =
        let isActive = Item.IsActive
        let props = Item.Props
        let customClass = Item.CustomClass
        let onClick = Item.OnClick

    let item (options: Item.Option list) children =
        let parseOptions (result: Item.Options) =
            function
            | Item.IsActive -> { result with IsActive = true }
            | Item.Props props -> { result with Props = props }
            | Item.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Item.OnClick cb -> { result with OnClick = cb |> Some }

        let opts = options |> List.fold parseOptions Item.Options.Empty
        let class' =
            [Bulma.Menu.State.IsActive, opts.IsActive]
            |> Helpers.classes Bulma.Menu.List [opts.CustomClass]
        let attrs =
            match opts.OnClick with
            | Some handler -> class'::(upcast DOMAttr.OnClick handler)::opts.Props
            | None -> class'::opts.Props

        li [ ] [ a attrs children ]
