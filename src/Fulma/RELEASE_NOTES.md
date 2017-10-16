### next

* BREAKING CHANGE: Fix icons display and implement Font Awesome helpers
* Fix #61: Add `is-fullwidth` support for Table element
* Fix #59: Add color support for the navbar compoenent
* Fix #67: Enforce DSL synthax with [<RequireQualifiedAccess>] attribute

### 1.0.0-beta-001

* Beta is ready for #FableConf ! ! !
* Implements `File` element
* Fix `Field.customClass` && `Field.props` type

### 0.2.0-beta-004

* Implement `Container`
* Implement `Footer`
* Implement `Hero`
* Implement `Section`
* Implement `Tile`
* BREAKING CHANGE: The `grid` module has been removed. You can find the `Columns` wrapper into `Layouts` module
* Fix `Navbar.menu` should generate a `div` not a `span`
* Fix `Navbar.menu` props
* Implements missing feature for `Button`
* Implement `Dropdown`
* Implements basic elements for `Form`

### 0.2.0-beta-003

* Implement `Modal`

### 0.2.0-beta-002

* Fulma is again a netstandard1.6 lib

### 0.2.0-beta-001

* Convert from Fable.Elmish.Bulma to Fulma
* BREAKING CHANGE: Remove `Nav` support as it's deprecated in Bulma. Please use `Navbar` instead
* BREAKING CHANGE: Move to Netstandard 2.0

### 0.1.1

* Implement `Tabs` components with documentation
* Implement `Notification` components with documentation

### 0.1.0-alpha.10

* Fix `Message` colors properties
* Add `Message` documentation
* Add `Size` properties to `Message`
* `Nav` has been dreprecated in Bulma. Users should use `Navbar` from now.
* Remove `FSharp.NET.Sdk` from the dependencies.
* Implement `Navbar` components with documentation
* Implement `Pagination` components with documentation
* Add explanation of how to use and and the architecture. (See Home page)

### 0.1.0-alpha9

* Add `Card` documentation
* Add `Media` documentation
* Add `Menu` documentation
* Add `Button.customClass` alias
* Add `State` to `Menu` declaration in `BulmaClasses`
* Add framework versions to the README.md
* Add `FontAwesome` convenience functions
* Remove `sprintf %s` in favor of the `+` operator (small performance improvments)

### 0.1.0-alpha8

* Fix #19: Refactored BulmaClasses to have more modules and literals
* Updated `bulma` to `Bulma` to give better represantation as module
* Performace improved and generated code reduced by 1800+ lines
* Add breadcrumb support
* Setup babel correctly for the docs site.
* Fix #13 : Move grids into their own namespace

### 0.1.0-alpha7

* Fix typo `typeIsSassword` -> `typeIsPassword`
* Implements `CustomClass` and `Props` for all the helpers

### 0.1.0-alpha6

* Fix #18: Heading should generate `title` by default
* Add Hero support
* Start implemententing `genericOptions`. Related to #16 & #17

### 0.1.0-alpha5

* Add Nav components support

### 0.1.0-alpha4

* Fix #15: Remove duplicate `IsLight`
* Fix `fable` nuget content (add all the **\*.fs files)

### 0.1.0-alpha-3

* Add box
* Add button
* Add content
* Add delete
* Add form
* Add headings
* Add icon
* Add image
* Add progress
* Add table
* Add tag
* Add grid (columns + column)
* Add card
* Add level
* Add media
* Add menu
* Add message
* Add panel

### 0.1.0-alpha-2
* Add icons support

### 0.1.0-alpha-1

* Start project
