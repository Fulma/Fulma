module Components.Menu.State

open Elmish
open Types

let basic =
    """
```fsharp
    let menuItem label isActive =
        li []
           [ a [ classList [ Bulma.Menu.State.IsActive, isActive ] ]
               [ str label ] ]

    let subMenu label isActive children =
        li []
           [ a [ classList [ Bulma.Menu.State.IsActive, isActive ] ]
                     [ str label ]
             ul [ ] children ]

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
```
    """

let init() =
    { Intro =
        """
# Menu

*[Bulma documentation](http://bulma.io/documentation/components/menu/)*
        """
      BasicViewer = Viewer.State.init basic }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg
