namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

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

        aside [ yield classBaseList Bulma.Menu.Container
                                    [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                yield! opts.Props ]
              children

    let label (options: GenericOption list) children =
        let opts = genericParse options

        p [ yield classBaseList Bulma.Menu.Label
                                [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
            yield! opts.Props ]
          children

    let list (options: GenericOption list) children =
        let opts = genericParse options

        ul [ yield classBaseList Bulma.Menu.List
                                 [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
             yield! opts.Props ]
           children

    module Item =
        let isActive = Item.IsActive
        let props = Item.Props
        let customClass = Item.CustomClass
        let onClick cb = Item.OnClick cb
    let item (options: Item.Option list) children =
        let parseOptions (result: Item.Options) =
            function
            | Item.IsActive -> { result with IsActive = true }
            | Item.Props props -> { result with Props = props }
            | Item.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Item.OnClick cb -> { result with OnClick = cb |> Some }

        let opts = options |> List.fold parseOptions Item.Options.Empty

        let className =
            [ if opts.IsActive then
                yield Bulma.Menu.State.IsActive
              if opts.CustomClass.IsSome then
                yield opts.CustomClass.Value
            ] |> String.concat " "


        li [] [
            a [ yield ClassName className :>  IHTMLProp
                if opts.OnClick.IsSome then
                    yield DOMAttr.OnClick opts.OnClick.Value :> IHTMLProp
                yield! opts.Props ]
                children
            ]
