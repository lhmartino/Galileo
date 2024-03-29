﻿using Flunt.Notifications;

namespace GalileoAPI.Domain;

public abstract class Entity : Notifiable<Notification>
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }    
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string EditedBy { get; set; }
    public DateTime EditedDate { get; set; }
}
