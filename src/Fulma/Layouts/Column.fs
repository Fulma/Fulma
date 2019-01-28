namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Column =

    type ISize =
        | [<CompiledName("is-one-quarter")>] IsOneQuarter
        | [<CompiledName("is-one-third")>] IsOneThird
        | [<CompiledName("is-half")>] IsHalf
        | [<CompiledName("is-two-thirds")>] IsTwoThirds
        | [<CompiledName("is-three-quarters")>] IsThreeQuarters
        | [<CompiledName("is-1")>] Is1
        | [<CompiledName("is-2")>] Is2
        | [<CompiledName("is-3")>] Is3
        | [<CompiledName("is-4")>] Is4
        | [<CompiledName("is-5")>] Is5
        | [<CompiledName("is-6")>] Is6
        | [<CompiledName("is-7")>] Is7
        | [<CompiledName("is-8")>] Is8
        | [<CompiledName("is-9")>] Is9
        | [<CompiledName("is-10")>] Is10
        | [<CompiledName("is-11")>] Is11
        | [<CompiledName("is-12")>] Is12
        | [<CompiledName("is-narrow")>] IsNarrow
        | [<CompiledName("is-full")>] IsFull
        | [<CompiledName("is-one-fifth")>] IsOneFifth
        | [<CompiledName("is-two-fifths")>] IsTwoFifths
        | [<CompiledName("is-three-fifths")>] IsThreeFifths
        | [<CompiledName("is-four-fifths")>] IsFourFifths

    type Option =
        /// Configure the width of the column. You can configure the display and size
        /// Example: Column.Width (Column.Desktop, Column.Is6)
        /// Becomes: `is-6-desktop`
        | Width of Screen * ISize
        /// Configure the offset of the column. You can configure the display and offset size
        /// Example: Column.Offset (Column.Desktop, Column.Is6)
        /// Becomes: `is-offset-6-desktop`
        | Offset of Screen * ISize
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    let private suffix = function
        | Screen.All -> ""
        | Screen.Desktop -> "-desktop"
        | Screen.Tablet -> "-tablet"
        | Screen.Mobile -> "-mobile"
        | Screen.WideScreen -> "-widescreen"
        | Screen.FullHD -> "-fullhd"
        | Screen.Touch -> "-touch"

    let internal ofWidth (screen, size) =
        Fable.Core.Reflection.getCaseName size + suffix screen

    let internal ofOffset (screen, offset) =
        let className = Fable.Core.Reflection.getCaseName offset
        "is-offset-" + className.[3..] + suffix screen

    /// Generate <div class="column"></div>
    let column (options : Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Width (screen, width) ->
                ofWidth (screen, width) |> result.AddClass
            | Offset (screen, offset) ->
                ofOffset (screen, offset) |> result.AddClass
            | CustomClass customClass ->
                result.AddClass customClass
            | Props props ->
                result.AddProps props
            | Modifiers modifiers ->
                result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "column")
            .ToReactElement(div, children)
