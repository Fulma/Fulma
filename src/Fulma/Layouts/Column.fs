namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Column =

    module Classes =
        let [<Literal>] Container = "column"

    type ISize =
        | [<CompiledName("is-one-quarter")>] IsOneQuarter
        | [<CompiledName("is-one-thirds")>] IsOneThird
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

    type internal Options =
        { Width : string option
          Offset : string option
          DesktopWidth : string option
          DesktopOffset : string option
          TabletpWidth : string option
          TabletpOffset : string option
          MobileWidth : string option
          MobileOffset : string option
          WideScreenWidth : string option
          WideScreenOffset : string option
          FullHDWidth : string option
          FullHDOffset : string option
          TouchWidth : string option
          TouchOffset : string option
          CustomClass : string option
          Props : IHTMLProp list
          Modifiers : string option list }
        static member Empty =
            { Width = None
              Offset = None
              DesktopWidth = None
              DesktopOffset = None
              TabletpWidth = None
              TabletpOffset = None
              MobileWidth = None
              MobileOffset = None
              WideScreenWidth = None
              WideScreenOffset = None
              FullHDWidth = None
              FullHDOffset = None
              TouchWidth = None
              TouchOffset = None
              CustomClass = None
              Props = []
              Modifiers = [] }

    /// Generate <div class="column"></div>
    let column (options : Option list) children =
        let parseOptions (result: Options) =
            function
            | Width (screen, width) when screen = Screen.All ->
                { result with Width = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = Screen.All ->
                { result with Offset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = Screen.Desktop ->
                { result with DesktopWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = Screen.Desktop ->
                { result with DesktopOffset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = Screen.Tablet ->
                { result with TabletpWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = Screen.Tablet ->
                { result with TabletpOffset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = Screen.Mobile ->
                { result with MobileWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = Screen.Mobile ->
                { result with MobileOffset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = Screen.WideScreen ->
                { result with WideScreenWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = Screen.WideScreen ->
                { result with WideScreenOffset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = Screen.FullHD ->
                { result with FullHDWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = Screen.FullHD ->
                { result with FullHDOffset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = Screen.Touch ->
                { result with TouchWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = Screen.Touch ->
                { result with TouchOffset = ofOffset (screen, offset) |> Some }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }
            | x ->
                Fable.Import.JS.console.warn("Error when parsing column option " + string x)
                result

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        ( opts.Width
                          ::opts.Offset
                          ::opts.DesktopWidth
                          ::opts.DesktopOffset
                          ::opts.MobileWidth
                          ::opts.MobileOffset
                          ::opts.TabletpWidth
                          ::opts.TabletpOffset
                          ::opts.WideScreenWidth
                          ::opts.WideScreenOffset
                          ::opts.FullHDWidth
                          ::opts.FullHDOffset
                          ::opts.TouchWidth
                          ::opts.TouchOffset
                          ::opts.CustomClass
                          ::opts.Modifiers )
                        [ ]
        div (classes::opts.Props) children
