# Spec Editor

This spike seeks to demonstrate that we can *auto-generate* a UI for quote filters, only using slightly modified versions of the [Specification](http://en.wikipedia.org/wiki/Specification_pattern) pattern that we're currently employing.  

![example UI](https://raw.githubusercontent.com/JohnVinyarduShip/SpecUI/master/Spec%20Editor.png)

Modifications include:

- Adding a method to validate the Specification data (e.g., for a hypothetical `MaxWeightInPounds` spec, we'd validate that the `MaxWeightInPounds.MaxPounds` property was greater than zero.
- Decorating classes and properties with attributes that provide text for the UI, e.g.
```c#
[Description("The shipment should not contain perishable items")]
public class NotPerishable {

    public bool IsSatisfied(Shipment shipment) {
        return !shipment.IsPerishable;
    }
}
```

The spike assumes that we'll be storing the specification data in a document or simple key value database, and *not* in a relational database.

## TODOs
- The UI code sucks pretty bad, and needs help
- Some of the type conversion code is awful.  I know we can do better.
- Some serious javascript refactoring is in order.  I chose knockout for the UI, but there may be a better choice.
- It should be possible to create custom UI for a particular spec, if needed
