module Components.Menu.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Elements.Form
open Fulma.Components
open Fulma.BulmaClasses

let menuItem label isActive =
    li []
       [ a [ classList [ Bulma.Menu.State.IsActive, isActive ] ]
           [ str label ] ]

let subMenu label isActive children =
    li []
       [ a [ classList [ Bulma.Menu.State.IsActive, isActive ] ]
                 [ str label ]
         ul [ ] children ]

let basic =
    Menu.menu [ ]
        [ Menu.label [ ] [ str "General" ]
          Menu.list [ ]
            [ menuItem "Dashboard" false
              menuItem "Customers" false ]
          Menu.label [ ] [ str "Administration" ]
          Menu.list [ ]
            [ menuItem "Team Settings" false
              subMenu "Manage your Team" true
                [ menuItem "Members" false
                  menuItem "Plugins" false
                  menuItem "Add a member" false ] ]
          Menu.label [ ] [ str "Transactions" ]
          Menu.list [ ]
            [ menuItem "Payments" false
              menuItem "Transfers" false
              menuItem "Balance" false ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch)) ]
