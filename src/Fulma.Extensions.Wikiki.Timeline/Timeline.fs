namespace Fulma.Extensions.Wikiki

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Timeline =
    type Option =
        /// Add `is-centered` class
        | [<CompiledName("is-centered")>] IsCentered
        /// Add `is-rtl` class
        | [<CompiledName("is-rtl")>] IsRtl
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    module Item =
        type Option =
            | Color of IColor
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

        module Marker =
            type Option =
                /// Add `is-16x16` class
                | [<CompiledName("is-16x16")>] Is16x16
                /// Add `is-24x24` class
                | [<CompiledName("is-24x24")>] Is24x24
                /// Add `is-32x32` class
                | [<CompiledName("is-32x32")>] Is32x32
                /// Add `is-48x48` class
                | [<CompiledName("is-48x48")>] Is48x48
                /// Add `is-64x64` class
                | [<CompiledName("is-64x64")>] Is64x64
                /// Add `is-96x96` class
                | [<CompiledName("is-96x96")>] Is96x96
                /// Add `is-128x128` class
                | [<CompiledName("is-128x128")>] Is128x128
                /// Add `is-icon` class
                | [<CompiledName("is-icon")>] IsIcon
                /// Add `is-image` class
                | [<CompiledName("is-image")>] IsImage
                | Color of IColor
                | Props of IHTMLProp list
                | CustomClass of string
                | Modifiers of Modifier.IModifier list

        let marker options children =
            let parseOptions (result : GenericOptions) option =
                match option with
                | Marker.Is16x16
                | Marker.Is24x24
                | Marker.Is32x32
                | Marker.Is48x48
                | Marker.Is64x64
                | Marker.Is96x96
                | Marker.Is128x128
                | Marker.IsIcon
                | Marker.IsImage -> result.AddCaseName option
                | Marker.Color color -> ofColor color |> result.AddClass
                | Marker.Props props -> result.AddProps props
                | Marker.CustomClass customClass -> result.AddClass customClass
                | Marker.Modifiers modifiers -> result.AddModifiers modifiers

            GenericOptions.Parse(options, parseOptions, "timeline-marker").ToReactElement(div, children)

        let content options children =
            GenericOptions.Parse(options, parseOptions, "timeline-content").ToReactElement(div, children)

        let item options children =
            let parseOptions (result : GenericOptions) option =
                match option with
                | Color color -> ofColor color |> result.AddClass
                | Props props -> result.AddProps props
                | CustomClass customClass -> result.AddClass customClass
                | Modifiers modifiers -> result.AddModifiers modifiers

            GenericOptions.Parse(options, parseOptions, "timeline-item").ToReactElement(div, children)

    module Header =
        let header options children =
            GenericOptions.Parse(options, parseOptions, "timeline-header").ToReactElement(header, children)

    let timeline options children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | IsCentered
            | IsRtl -> result.AddCaseName option
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "timeline").ToReactElement(div, children)
