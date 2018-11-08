**Simple spread sheet**

A simple program where an end user will be able performing some basic spreadsheet operation
---

## Run application

1. Clone the code.
2. Use vs2015 or height open SimpleSpreadsheet.sln file.
3. Run or debug SimpleSpreadsheet.Console project.
---

## Unit test

Read above for open SimpleSpreadsheet solution

1. Open Test resource management view.
2. Select CommandTest node, run these test.

---

## Design consideration

1. I introduce Autofac for the DIP.
2. Use CommandRoute for add new command but not more edit code.
3. It implements command  Pattern, so the command result is flexible, and command implement is independent.
4. Consider the application is a demo, so data persistence is not design.