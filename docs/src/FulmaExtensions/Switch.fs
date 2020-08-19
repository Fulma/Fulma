module FulmaExtensions.Switch

open Fable.Core
open Fable.Import
open Fable.React
open Fable.React.Props
open Fulma
open Fulma.Extensions.Wikiki
open Fable.FontAwesome

let inlineBlockInteractive () =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                [ b [ ] [ str "Block" ]
                  Switch.switch [ Switch.Id "switch-1" ]
                    [ str "One" ]
                  Switch.switch [ Switch.Id "switch-2" ]
                    [ str "Two" ]
                  // ----------------
                  b [ ] [ str "Inline" ]
                  Field.div [ ]
                      [ Switch.switchInline [ Switch.Id "switch-3" ]
                            [ str "One" ]
                        Switch.switchInline [ Switch.Id "switch-4"
                                              Switch.LabelProps [ Style [ MarginLeft "2rem" ] ] ]
                            [ str "Two" ] ] ] ] ]

let rtl () =
    Switch.switch [ Switch.IsRtl
                    Switch.Id "switch-5" ]
        [ str "Label is on the left" ]


type SwitchColorDemoProps =
    interface end

type SwitchColorDemoState =
    { States : Map<string, bool> }

type SwitchColorDemo(props) =
    inherit Component<SwitchColorDemoProps, SwitchColorDemoState>(props)
    do base.setInitState({ States = Map.empty })

    member this.onStateChange key _ =
        this.setState (fun prevState _ ->
            { prevState with
                States = Map.add key (not (this.getState key)) prevState.States
            }
        )

    member this.getState (id : string) =
        match Map.tryFind id this.state.States with
        | Some state ->
            state

        | None ->
            true

    override this.render () =
        Columns.columns [ ]
            [ Column.column [ ]
                [ div [ ClassName "block" ]
                      [ Switch.switch [ Switch.Checked (this.getState "switch-color-6")
                                        Switch.OnChange (this.onStateChange "switch-color-6")
                                        Switch.Id "switch-color-6" ]
                            [ str "Default" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-color-7")
                                        Switch.OnChange (this.onStateChange "switch-color-7")
                                        Switch.Id "switch-color-7"
                                        Switch.Color IsWhite ]
                            [ str "White" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-color-8")
                                        Switch.OnChange (this.onStateChange "switch-color-8")
                                        Switch.Id "switch-color-8"
                                        Switch.Color IsLight ]
                            [ str "Light" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-color-9")
                                        Switch.OnChange (this.onStateChange "switch-color-9")
                                        Switch.Id "switch-color-9"
                                        Switch.Color IsDark ]
                            [ str "Dark" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-color-10")
                                        Switch.OnChange (this.onStateChange "switch-color-10")
                                        Switch.Id "switch-color-10"
                                        Switch.Color IsBlack ]
                            [ str "Black" ] ] ]
              // ----------------
              Column.column [ ]
                [ div [ ClassName "block" ]
                      [ Switch.switch [ Switch.Checked (this.getState "switch-color-11")
                                        Switch.OnChange (this.onStateChange "switch-color-11")
                                        Switch.Id "switch-color-11"
                                        Switch.Color IsPrimary ]
                            [ str "Primary" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-color-12")
                                        Switch.OnChange (this.onStateChange "switch-color-12")
                                        Switch.Id "switch-color-12"
                                        Switch.Color IsInfo ]
                            [ str "Info" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-color-13")
                                        Switch.OnChange (this.onStateChange "switch-color-13")
                                        Switch.Id "switch-color-13"
                                        Switch.Color IsSuccess ]
                            [ str "Success" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-color-14")
                                        Switch.OnChange (this.onStateChange "switch-color-14")
                                        Switch.Id "switch-color-14"
                                        Switch.Color IsWarning ]
                            [ str "Warning" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-color-15")
                                        Switch.OnChange (this.onStateChange "switch-color-15")
                                        Switch.Id "switch-color-15"
                                        Switch.Color IsDanger ]
                            [ str "Danger" ] ] ] ]

type SwitchSizeDemoProps =
    interface end

type SwitchSizeDemoState =
    { States : Map<string, bool> }

type SwitchSizeDemo(props) =
    inherit Component<SwitchSizeDemoProps, SwitchSizeDemoState>(props)
    do base.setInitState({ States = Map.empty })

    member this.onStateChange key _ =
        this.setState (fun prevState _ ->
            { prevState with
                States = Map.add key (not (this.getState key)) prevState.States
            }
        )

    member this.getState (id : string) =
        match Map.tryFind id this.state.States with
        | Some state ->
            state

        | None ->
            true

    override this.render () =
        div [ ClassName "block" ]
            [ Switch.switch [ Switch.Checked (this.getState "switch-size-16")
                              Switch.OnChange (this.onStateChange "switch-size-16")
                              Switch.Id "switch-size-16"
                              Switch.Size IsSmall ]
                [ str "Small" ]
              Switch.switch [ Switch.Checked (this.getState "switch-size-17")
                              Switch.OnChange (this.onStateChange "switch-size-17")
                              Switch.Id "switch-size-17" ]
                [ str "Normal" ]
              Switch.switch [ Switch.Checked (this.getState "switch-size-18")
                              Switch.OnChange (this.onStateChange "switch-size-18")
                              Switch.Id "switch-size-18"
                              Switch.Size IsMedium ]
                [ str "Medium" ]
              Switch.switch [ Switch.Checked (this.getState "switch-size-19")
                              Switch.OnChange (this.onStateChange "switch-size-19")
                              Switch.Id "switch-size-19"
                              Switch.Size IsLarge ]
                [ str "Large" ] ]

type SwitchStylesDemoProps =
    interface end

type SwitchStylesDemoState =
    { States : Map<string, bool> }

type SwitchStylesDemo(props) =
    inherit Component<SwitchStylesDemoProps, SwitchStylesDemoState>(props)
    do base.setInitState({ States = Map.empty })

    member this.onStateChange key _ =
        this.setState (fun prevState _ ->
            { prevState with
                States = Map.add key (not (this.getState key)) prevState.States
            }
        )

    member this.getState (id : string) =
        match Map.tryFind id this.state.States with
        | Some state ->
            state

        | None ->
            true

    override this.render () =
        Columns.columns [ ]
            [ Column.column [ ]
                [ div [ ClassName "block" ]
                      [ Switch.switch [ Switch.Checked (this.getState "switch-style-20")
                                        Switch.OnChange (this.onStateChange "switch-style-20")
                                        Switch.Id "switch-style-20"
                                        Switch.IsRounded
                                        Switch.Disabled true ]
                            [ str "Disabled" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-21")
                                        Switch.OnChange (this.onStateChange "switch-style-21")
                                        Switch.Id "switch-style-21"
                                        Switch.IsRounded
                                        Switch.Color IsPrimary ]
                            [ str "Checkbox" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-22")
                                        Switch.OnChange (this.onStateChange "switch-style-22")
                                        Switch.Id "switch-style-22"
                                        Switch.IsRounded
                                        Switch.Color IsSuccess ]
                            [ str "Checkbox - success" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-23")
                                        Switch.OnChange (this.onStateChange "switch-style-23")
                                        Switch.Id "switch-style-23"
                                        Switch.IsRounded
                                        Switch.Color IsWarning ]
                            [ str "Checkbox - warning" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-24")
                                        Switch.OnChange (this.onStateChange "switch-style-24")
                                        Switch.Id "switch-style-24"
                                        Switch.IsRounded
                                        Switch.Color IsDanger ]
                            [ str "Checkbox - danger" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-25")
                                        Switch.OnChange (this.onStateChange "switch-style-25")
                                        Switch.Id "switch-style-25"
                                        Switch.IsRounded
                                        Switch.Color IsInfo ]
                            [ str "Checkbox - info" ] ] ]
              // ----------------
              Column.column [ ]
                [ div [ ClassName "block" ]
                      [ Switch.switch [ Switch.Checked (this.getState "switch-style-26")
                                        Switch.OnChange (this.onStateChange "switch-style-26")
                                        Switch.Id "switch-style-26"
                                        Switch.IsThin
                                        Switch.Disabled true ]
                            [ str "Disabled" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-27")
                                        Switch.OnChange (this.onStateChange "switch-style-27")
                                        Switch.Id "switch-style-27"
                                        Switch.IsThin
                                        Switch.Color IsPrimary ]
                            [ str "Checkbox" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-28")
                                        Switch.OnChange (this.onStateChange "switch-style-28")
                                        Switch.Id "switch-style-28"
                                        Switch.IsThin
                                        Switch.Color IsSuccess ]
                            [ str "Checkbox - success" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-29")
                                        Switch.OnChange (this.onStateChange "switch-style-29")
                                        Switch.Id "switch-style-29"
                                        Switch.IsThin
                                        Switch.Color IsWarning ]
                            [ str "Checkbox - warning" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-30")
                                        Switch.OnChange (this.onStateChange "switch-style-30")
                                        Switch.Id "switch-style-30"
                                        Switch.IsThin
                                        Switch.Color IsDanger ]
                            [ str "Checkbox - danger" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-31")
                                        Switch.OnChange (this.onStateChange "switch-style-31")
                                        Switch.Id "switch-style-31"
                                        Switch.IsThin
                                        Switch.Color IsInfo ]
                            [ str "Checkbox - info" ] ] ]
              // ----------------
              Column.column [ ]
                [ div [ ClassName "block" ]
                      [ Switch.switch [ Switch.Checked (this.getState "switch-style-32")
                                        Switch.OnChange (this.onStateChange "switch-style-32")
                                        Switch.Id "switch-style-32"
                                        Switch.IsOutlined
                                        Switch.Disabled true ]
                            [ str "Disabled" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-33")
                                        Switch.OnChange (this.onStateChange "switch-style-33")
                                        Switch.Id "switch-style-33"
                                        Switch.IsOutlined
                                        Switch.Color IsPrimary ]
                            [ str "Checkbox" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-34")
                                        Switch.OnChange (this.onStateChange "switch-style-34")
                                        Switch.Id "switch-style-34"
                                        Switch.IsOutlined
                                        Switch.Color IsSuccess ]
                            [ str "Checkbox - success" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-35")
                                        Switch.OnChange (this.onStateChange "switch-style-35")
                                        Switch.Id "switch-style-35"
                                        Switch.IsOutlined
                                        Switch.Color IsWarning ]
                            [ str "Checkbox - warning" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-36")
                                        Switch.OnChange (this.onStateChange "switch-style-36")
                                        Switch.Id "switch-style-36"
                                        Switch.IsOutlined
                                        Switch.Color IsDanger ]
                            [ str "Checkbox - danger" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-37")
                                        Switch.OnChange (this.onStateChange "switch-style-37")
                                        Switch.Id "switch-style-37"
                                        Switch.IsOutlined
                                        Switch.Color IsInfo ]
                            [ str "Checkbox - info" ] ] ]
              // ----------------
              Column.column [ ]
                [ div [ ClassName "block" ]
                      [ Switch.switch [ Switch.Checked (this.getState "switch-style-38")
                                        Switch.OnChange (this.onStateChange "switch-style-38")
                                        Switch.Id "switch-style-38"
                                        Switch.IsRounded
                                        Switch.IsOutlined
                                        Switch.Disabled true ]
                            [ str "Disabled" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-39")
                                        Switch.OnChange (this.onStateChange "switch-style-39")
                                        Switch.Id "switch-style-39"
                                        Switch.IsRounded
                                        Switch.IsOutlined
                                        Switch.Color IsPrimary ]
                            [ str "Checkbox" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-40")
                                        Switch.OnChange (this.onStateChange "switch-style-40")
                                        Switch.Id "switch-style-40"
                                        Switch.IsRounded
                                        Switch.IsOutlined
                                        Switch.Color IsSuccess ]
                            [ str "Checkbox - success" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-41")
                                        Switch.OnChange (this.onStateChange "switch-style-41")
                                        Switch.Id "switch-style-41"
                                        Switch.IsRounded
                                        Switch.IsOutlined
                                        Switch.Color IsWarning ]
                            [ str "Checkbox - warning" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-42")
                                        Switch.OnChange (this.onStateChange "switch-style-42")
                                        Switch.Id "switch-style-42"
                                        Switch.IsRounded
                                        Switch.IsOutlined
                                        Switch.Color IsDanger ]
                            [ str "Checkbox - danger" ]
                        Switch.switch [ Switch.Checked (this.getState "switch-style-43")
                                        Switch.OnChange (this.onStateChange "switch-style-43")
                                        Switch.Id "switch-style-43"
                                        Switch.IsRounded
                                        Switch.IsOutlined
                                        Switch.Color IsInfo ]
                            [ str "Checkbox - info" ] ] ] ]

let stateInteractive () =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.Disabled true
                          Switch.Id "switch-44" ]
            [ str "Disabled" ]
          Switch.switch [ Switch.Disabled true
                          Switch.Checked true
                          Switch.Id "switch-45" ]
            [ str "Disabled & Checked" ]
          Switch.switch [ Switch.Id "switch-unchecked-1" ]
            [ str "Unchecked" ]
          Switch.switch [ Switch.Checked true
                          Switch.Id "switch-46" ]
            [ str "checked" ] ]

type SwitchDemoProps =
    interface end

type SwitchDemoState =
    { IsChecked : bool }

type SwitchDemo(props) =
    inherit Component<SwitchDemoProps, SwitchDemoState>(props)
    do base.setInitState({ IsChecked = false })

    member this.toggleState _ =
        this.setState (fun prevState _ ->
            { prevState with IsChecked = not this.state.IsChecked}
        )

    override this.render () =
        div [ ClassName "block" ]
            [ Switch.switch
                [ Switch.Checked this.state.IsChecked
                  Switch.Id "switch-47"
                  Switch.OnChange this.toggleState ]
                [ str (string this.state.IsChecked) ]
              Switch.switch
                [ Switch.Checked this.state.IsChecked
                  Switch.Id "switch-48"
                  Switch.OnChange this.toggleState ]
                [ if this.state.IsChecked then
                    yield Icon.icon [ ]
                            [ Fa.i [ Fa.Solid.Check ]
                                [ ] ]
                  else
                    yield Icon.icon [ ]
                            [ Fa.i [ Fa.Solid.Times ]
                                [ ] ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Switch

The **Switch** can have different colors, sizes and states.

*[Documentation](https://wikiki.github.io/form/switch/)*

### Installation

- Choose depending on your package manager:
    - `paket add Fulma.Extensions.Wikiki.Switch --project <your project>`
    - `dotnet add <your project> package Fulma.Extensions.Wikiki.Switch`
- Follow instructions from `dotnet femto yourProject.fsproj` - [Femto documentation](https://github.com/Zaid-Ajaj/Femto/)
- Don't forget to configure the npm package in your project
                        """
                     Render.docSection
                        """
<div class="message is-info">
    <div class="message-body">
        You need to provide <code>Switch.Id "unique-id"</code> in order to make <code>Switch</code> works
    </div>
</div>

### Inline vs Block
                        """
                        (Widgets.Showcase.view inlineBlockInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Text position"
                        (Widgets.Showcase.view rtl (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Colors"
                        (Widgets.Showcase.view (fun _ -> ofType<SwitchColorDemo,_,_> (unbox null) []) (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view (fun _ -> ofType<SwitchSizeDemo,_,_> (unbox null) []) (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Styles
The switch can be **rounded, outlined, thin or any combinaison of those**.
                        """
                        (Widgets.Showcase.view (fun _ -> ofType<SwitchStylesDemo,_,_> (unbox null) []) (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### States"
                        (Widgets.Showcase.view stateInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Event handler"
                        (Widgets.Showcase.view (fun _ -> ofType<SwitchDemo,_,_> (unbox null) []) (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
