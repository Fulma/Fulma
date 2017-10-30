namespace Fulma.Layouts

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Level =

    module Types =

        module Level =

            type Option =
                | Props of IHTMLProp list
                | IsMobile
                | CustomClass of string

            type Options =
                { Props : IHTMLProp list
                  IsMobile : bool
                  CustomClass : string option }

                static member Empty =
                    { Props = []
                      IsMobile = false
                      CustomClass = None }

        module Item =

            type Option =
                | Props of IHTMLProp list
                | HasTextCentered
                | CustomClass of string

            type Options =
                { Props : IHTMLProp list
                  HasTextCentered : bool
                  CustomClass : string option }

                static member Empty =
                    { Props = []
                      HasTextCentered = false
                      CustomClass = None }

    open Types

    module Level =
        let inline isMobile<'T> = Level.IsMobile
        // Extra
        let inline props x = Level.Props x
        let inline customClass x = Level.CustomClass x

    let level (options : Level.Option list) children =
        let parseOptions (result: Level.Options ) opt =
            match opt with
            | Level.Option.Props props -> { result with Props = props }
            | Level.Option.IsMobile -> { result with IsMobile = true }
            | Level.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Level.Options.Empty
        let class' = Helpers.classes Bulma.Level.Container [opts.CustomClass]
                        [ Bulma.Level.Mobile.IsHorizontal, opts.IsMobile ]

        nav (class'::opts.Props) children

    let inline props x = GenericOption.Props x
    let inline customClass x = GenericOption.CustomClass x

    let left (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Level.Left [opts.CustomClass] []

        div (class'::opts.Props) children

    let right (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Level.Right [opts.CustomClass] []

        div (class'::opts.Props) children

    module Item =
        let inline hasTextCentered<'T> = Item.HasTextCentered
        // Extra
        let inline props x = Item.Props x
        let inline customClass x = Item.CustomClass x

    module Heading =
        let inline props x = GenericOption.Props x
        let inline customClass x = GenericOption.CustomClass x

    module Title =
        let inline props x = GenericOption.Props x
        let inline customClass x = GenericOption.CustomClass x

    let item (options : Item.Option list) children =
        let parseOptions (result: Item.Options ) opt =
            match opt with
            | Item.Props props -> { result with Props = props }
            | Item.HasTextCentered -> { result with HasTextCentered = true }
            | Item.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Item.Options.Empty
        let class' = Helpers.classes Bulma.Level.Item.Container [opts.CustomClass]
                        [ Bulma.Level.Item.HasTextCentered, opts.HasTextCentered ]

        nav (class'::opts.Props) children

    let heading (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Level.Item.Heading [opts.CustomClass] []

        p (class'::opts.Props) children

    let title (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Level.Item.Title [opts.CustomClass] []

        p (class'::opts.Props) children
