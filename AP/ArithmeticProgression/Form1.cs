using MathCollection;
using System.Drawing;

namespace ArithmeticProgression; 


public partial class Form1 : Form
{
    System.Windows.Forms.Timer timer;
    Vector2 position = new Vector2(100, 100); // Initial position
    Vector2 velocity = new Vector2(0, 0);      // Initial velocity

    float acceleration = 20f; // Common difference for AP
    float maxSpeed = 400f;
    bool wPressed = false;
    bool aPressed = false;
    bool sPressed = false;
    bool dPressed = false;
    int intervalTime = 16;
    private bool useLerp = true;

    public Form1()
    {
        InitializeComponent();

        this.DoubleBuffered = true; // Important! Prevents flickering when drawing

        timer = new System.Windows.Forms.Timer();
        timer.Interval = intervalTime; // ~60 FPS
        timer.Tick += Update;
        timer.Start();

        this.KeyDown += OnKeyDown;
        this.KeyUp += OnKeyUp;
    }

    void Update(object sender, EventArgs e)
    {

        // If you want to switch easily:
        // useLerp = true;
        if (useLerp)
            withLerp();
        else
            withOutLerp();

        // Apply velocity to position
        float deltaTime = intervalTime / 1000f;
        position.x += velocity.x * deltaTime;
        position.y += velocity.y * deltaTime;


        this.Invalidate(); // Redraw
    }

    private void withOutLerp()
    {
        if (wPressed)
            velocity.y = -maxSpeed;
        else if (sPressed)
            velocity.y = maxSpeed;
        else
            velocity.y = 0;

        if (aPressed)
            velocity.x = -maxSpeed;
        else if (dPressed)
            velocity.x = maxSpeed;
        else
            velocity.x = 0;
    }

    private void withLerp()
    {
        if (wPressed)
            velocity.y = lerp(velocity.y, -maxSpeed, acceleration);
        else if (sPressed)
            velocity.y = lerp(velocity.y, maxSpeed, acceleration);
        else
            velocity.y = lerp(velocity.y, 0, acceleration);

        if (aPressed)
            velocity.x = lerp(velocity.x, -maxSpeed, acceleration);
        else if (dPressed)
            velocity.x = lerp(velocity.x, maxSpeed, acceleration);
        else
            velocity.x = lerp(velocity.x, 0, acceleration);
    }

    float lerp(float value, float target, float acceleration)
    {
        if (value < target)
        {
            value += acceleration;
            if (value > target)
                value = target;
        }
        else if (value > target)
        {
            value -= acceleration;
            if (value < target)
                value = target;
        }

        return value;
    }



    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw a blue square
        e.Graphics.FillRectangle(Brushes.Blue, position.x, position.y, 50, 50);


        //calibration
        using (Font font = new Font("Arial", 12))
        using (Brush greenBrush = new SolidBrush(Color.Green))
        using (Brush redBrush = new SolidBrush(Color.Red))
        using (Brush blueBrush = new SolidBrush(Color.Blue))
        {
            // Prepare text
            string velocityText = $"Velocity: ({velocity.x:F2}, {velocity.y:F2})";
            string positionText = $"Position: ({position.x:F2}, {position.y:F2})";
            string modeText = $"Movement Mode: {(useLerp ? "Lerp" : "Instant")}";

            // Instead of measuring dynamic text, measure the WIDEST string
            string sampleText = "Velocity: (000.00, 000.00)"; // Worst case width
            SizeF sampleSize = e.Graphics.MeasureString(sampleText, font);

            float x = this.ClientSize.Width - sampleSize.Width - 40; // Fixed margin
            float y = 10;

            // Draw lines
            e.Graphics.DrawString(velocityText, font, redBrush, x, y);
            y += sampleSize.Height + 5;

            e.Graphics.DrawString(positionText, font, greenBrush, x, y);
            y += sampleSize.Height + 5;

            e.Graphics.DrawString(modeText, font, blueBrush, x, y);
        }
    }


    void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.W) wPressed = true;
        if (e.KeyCode == Keys.A) aPressed = true;
        if (e.KeyCode == Keys.S) sPressed = true;
        if (e.KeyCode == Keys.D) dPressed = true;
    }

    void OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.W) wPressed = false;
        if (e.KeyCode == Keys.A) aPressed = false;
        if (e.KeyCode == Keys.S) sPressed = false;
        if (e.KeyCode == Keys.D) dPressed = false;
    }

}